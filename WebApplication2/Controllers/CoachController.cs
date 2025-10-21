using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.IRepos;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        readonly ICoachRepo _coachRepo;
        public CoachController(ICoachRepo coachRepo)
        {
            _coachRepo = coachRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCoaches()
        {
            var coach= await _coachRepo.GetAllCoachesAsync();
            if(coach==null) return NotFound();

            var coaches = coach.GroupBy(x => x.Specialization)
                .Select(c => new
                {
                   Specialization= c.Key,
                } );

        
            return Ok(coaches);
        }

        //[HttpGet("{Id}")]
        //public async Task<IActionResult> GetcoachById(int id)
        //{
        //    var co = await _coachRepo.GetCoachById(id);
        //    if (co == null) return NotFound();

        //    //var coaches = 
        //    return Ok(coaches);
        //}
    }
}















