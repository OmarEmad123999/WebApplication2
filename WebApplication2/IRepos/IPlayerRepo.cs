using WebApplication2.Models;

namespace WebApplication2.IRepos
{
    public interface IPlayerRepo:IGenericRepo<Player>
    {
        public Task<IEnumerable<Player>> GetAllPlayersAsync();
    }
}
