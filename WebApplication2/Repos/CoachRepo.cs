using Microsoft.EntityFrameworkCore;
using WebApplication2.IRepos;
using WebApplication2.Models;

namespace WebApplication2.Repos
{
    public class CoachRepo : GenericRepo<Coach>, ICoachRepo
    {
        readonly AppDbContext _db;
        public CoachRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Coach>> GetAllCoachesAsync()
        {
            return await _db.Coaches.Include(x => x.Team).ToListAsync();
            
        }

        public async Task<Coach?> GetCoachById(int id)
        {
          return  await _db.Coaches.Include(x=> x.Team).ThenInclude(x=> x.Players).FirstOrDefaultAsync(x=> x.Id == id);

        }
    }
}
