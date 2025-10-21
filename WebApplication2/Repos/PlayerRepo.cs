using Microsoft.EntityFrameworkCore;
using WebApplication2.IRepos;
using WebApplication2.Models;

namespace WebApplication2.Repos
{
    public class PlayerRepo : GenericRepo<Player>, IPlayerRepo
    {
        readonly AppDbContext _db;
        public PlayerRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
           return await _db.Players.Include(x=> x.Team).ToListAsync();
        }
    }
}
