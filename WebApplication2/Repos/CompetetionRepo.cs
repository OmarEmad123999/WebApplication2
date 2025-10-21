using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication2.IRepos;
using WebApplication2.Models;

namespace WebApplication2.Repos
{
    public class CompetetionRepo : GenericRepo<Competetion>, ICompetitionRepo
    {
        readonly AppDbContext _db;
        public CompetetionRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Competetion> DeleteCompBYId(int id)
        {
            return await _db.competetions.FindAsync(id);
        }

        public async Task<IEnumerable<Competetion>> GetAllCompetetions()
        {
            return await _db.competetions.Include(x=> x.teams).ThenInclude(x=> x.Players).ToListAsync();
        }
    }
}
