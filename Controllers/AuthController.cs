using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortfolioSiteApi.Data;
using PortfolioSiteApi.Models;
using PortfolioSiteApi.Tools;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController: ControllerBase
{
     private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration, AppDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginModel.Username);

        if (user==null || !Encrypter.CheckPassword(loginModel.Password,user.Password))
        {
            return Unauthorized();
        }

        var token = GenerateJwtToken(user.Email);

        return Ok(new { token});
    }

   

   

    private string GenerateJwtToken(string username)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: new[]
            {
                new Claim(ClaimTypes.Name, username)
            },
            expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:Expires"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}