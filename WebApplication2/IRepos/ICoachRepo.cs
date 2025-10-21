using WebApplication2.Models;

namespace WebApplication2.IRepos
{
    public interface ICoachRepo:IGenericRepo<Coach>
    {
        public Task<IEnumerable<Coach>> GetAllCoachesAsync();
        public Task<Coach?> GetCoachById(int id);
    }
}
