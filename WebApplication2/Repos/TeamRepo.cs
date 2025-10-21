using Microsoft.EntityFrameworkCore;
using WebApplication2.IRepos;
using WebApplication2.Models;

namespace WebApplication2.Repos
{
    public class TeamRepo : GenericRepo<Team>, ITeamRepo
    {
        readonly AppDbContext _db;
        public TeamRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Team>> GitAllTeamesnoncompetetion()
        {
          return await _db.Teams.Where(x=> !x.competetions.Any()).Include(x=>x.competetions).ToListAsync();
        }
    }
}
