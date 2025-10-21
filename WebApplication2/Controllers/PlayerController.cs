using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.IRepos;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        readonly IPlayerRepo _playerRepo;
        public PlayerController(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(int id, UpdatePlayerDTO playerDTO)
        {

            var player = await _playerRepo.GetByIdAsync(id);
            if (player == null) return BadRequest("Player Not Found");

            player.Position=playerDTO.Position;
            _playerRepo.Update(player);
            await _playerRepo.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var player =await _playerRepo.GetAllPlayersAsync();
            if (player == null) return NotFound();

            var groubed = player.GroupBy(x => x.Age)
                .Select(p => new
                {
                    Age=p.Key
                }
                ).ToList();

            return Ok(groubed);
        }
    }
}



