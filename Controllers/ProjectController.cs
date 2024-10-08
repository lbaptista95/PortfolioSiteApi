using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSiteApi.Data;
using PortfolioSiteApi.Models.Entity;
using PortfolioSiteApi.Models.DTO;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{

    private readonly AppDbContext _context;

    public ProjectController(AppDbContext context)
    {
        _context = context;
    }

    //GET: api/Project

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetProjects()
    {
        var projects = await _context.Projects
        .AsSplitQuery()
        .Include(p => p.MediaProjects)
            .ThenInclude(mp => mp.Media)
        .Include(p => p.SkillProjects)
            .ThenInclude(sp => sp.Skill)
       .Select(p => new ProjectResponse
       {
           Id = p.Id,
           Name = p.Name,
           Description = p.Description,
           Company = p.Company,
           MediaList = p.MediaProjects.Select(mp => mp.Media).ToList(),
           SkillNames = p.SkillProjects.Select(sp => sp.Skill.Name).ToList()
       })
       .ToListAsync();

        return Ok(projects);
    }

}

