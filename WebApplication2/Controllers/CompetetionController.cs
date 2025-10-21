using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.IRepos;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetetionController : ControllerBase
    {
        readonly ICompetitionRepo _competitionRepo;
        public CompetetionController(ICompetitionRepo competitionRepo)
        {
            _competitionRepo = competitionRepo;
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var comp = await _competitionRepo.DeleteCompBYId(id);

            if (comp == null) return NotFound();
          
            _competitionRepo.Delete(comp);
            await _competitionRepo.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComps()
        { 
            var comp = await _competitionRepo.GetAllCompetetions();

            var competetions = comp.GroupBy(x => x.Location)
                .Select(x => new
                {
                    location = x.Key,

                    competetions = x.Key
                    .Select(c=> new CompetetionsDTO 
                    {
                        //okok
                    }
                    
                    ).ToList()  
                }
                ).ToList();
            return Ok(competetions);
        }
    }
}
