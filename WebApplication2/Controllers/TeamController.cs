using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.IRepos;
using WebApplication2.Models;
using WebApplication2.Repos;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        readonly ITeamRepo _teamRepo;
        public TeamController(ITeamRepo teamRepo)
        {
            _teamRepo = teamRepo;
        }
        [HttpPost]
        public async Task<IActionResult> AddTeam(PostTeamDTO dTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var coach = _teamRepo.GetByIdAsync(dTO.CoachId);
            if (coach == null) return BadRequest("Coach Not Found");

            var teames = new Team
            {
                Name = dTO.Name,
                City = dTO.City,
                CoachId = dTO.CoachId,
            };
            await _teamRepo.AddAsync(teames);
            await _teamRepo.SaveChangesAsync();
            return Created();
           
        }
        [HttpGet]
        public async Task<IActionResult> GetTeamsnoncompetetion()
        {
            var team = await _teamRepo.GitAllTeamesnoncompetetion();
            if (team == null) return NotFound();



            var teames = team.Select(x => new TeamDTO
            {
                Id = x.Id,
                Name = x.Name,
                City= x.City,
                CoachId = x.CoachId,
                Playercount = x.Players.Count()

            }
              ).OrderByDescending(x=> x.Playercount).ToList();
            return Ok(teames);
        }
    }
}















