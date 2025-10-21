using WebApplication2.Models;

namespace WebApplication2.IRepos
{
    public interface ITeamRepo : IGenericRepo<Team>
    {
        public Task<IEnumerable<Team>> GitAllTeamesnoncompetetion();
    }
}
