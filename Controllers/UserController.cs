using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSiteApi.Data;
using PortfolioSiteApi.Models;
using PortfolioSiteApi.Tools;
using PortfolioSiteApi.Helpers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly EmailService _emailService;

    public UserController(AppDbContext context, EmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    //GET: api/User

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    //GET api/User/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user==null)
        {            
            return NotFound();
        }

        return user;
    }

     //GET api/User/{id}
    [HttpGet("fields")]
    public async Task<ActionResult<User>> GetUserFields()
    {
        List<string> notNeededColumns = ["Id", "EmailConfirmed"];

        var schema = SchemaHelper.GetTableSchema<User>(_context,notNeededColumns);
        
        return Ok(schema);
    }

    [HttpGet("confirm")]

    public async Task<IActionResult> ConfirmUser(int userId)
    {
        User user = await _context.Users.FindAsync(userId);

        if(user == null)
        {
            return NotFound();
        }

        user.EmailConfirmed = true;

        await _context.SaveChangesAsync();

        return Ok("User confirmed!");
    }


    //POST api/User

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        user.Password = Encrypter.GeneratePasswordHash(user.Password);
        
        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        var confirmationLink = Url.Action(nameof(ConfirmUser),"User", new {userId = user.Id},Request.Scheme);

        string emailMessage = $"Please, confirm your account by clicking here: <a href='{confirmationLink}'>Confirm your e-mail</a>";

        await _emailService.SendEmailAsync(user,"Account confirmation", emailMessage);

        return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
    }


    //PUT api/user/{id}

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {
        if (id!=user.Id)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if(user==null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserExists(int id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}