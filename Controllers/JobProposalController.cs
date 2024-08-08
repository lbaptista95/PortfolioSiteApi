using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSiteApi.Data;
using PortfolioSiteApi.Models;

[Route("api/[controller]")]
[ApiController]
public class JobProposalController : ControllerBase
{

    private readonly AppDbContext _context;

    public JobProposalController(AppDbContext context)
    {
        _context = context;
    }

    //GET: api/JobProposal

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobProposal>>> GetJobProposals()
    {
        return await _context.JobProposals.ToListAsync();
    }

    //GET: api/JobProposal/{id}

    [HttpGet("{id}")]
    public async Task<ActionResult<JobProposal>> GetJobProposal(int id)
    {
        var jobProposal = await _context.JobProposals.FindAsync(id);

        if (jobProposal==null)
        {            
            return NotFound();
        }

        return jobProposal;
    }

    //GET: api/JobProposal/GetFromUser

    [HttpGet("GetFromUser")]
    public async Task<ActionResult<IEnumerable<JobProposal>>> GetJobProposalsByUser([FromBody] User user)
    {
        var jobProposals = await _context.JobProposals.Where(j => j.UserId == user.Id).ToListAsync();

        if(jobProposals== null || jobProposals.Count == 0)
        {
            return NotFound("There is no job proposal made by this user");
        }

        return Ok(jobProposals);
    }

    //POST api/User

    [HttpPost]
    public async Task<ActionResult<JobProposal>> PostJobProposal(JobProposal jobProposal)
    {
        _context.JobProposals.Add(jobProposal);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetJobProposal), new {id = jobProposal.Id}, jobProposal);
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