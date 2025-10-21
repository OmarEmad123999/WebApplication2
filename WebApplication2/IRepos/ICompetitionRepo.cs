using WebApplication2.Models;

namespace WebApplication2.IRepos
{
    public interface ICompetitionRepo:IGenericRepo<Competetion>
    {
        public Task<Competetion> DeleteCompBYId(int id);
        public Task<IEnumerable<Competetion>> GetAllCompetetions();
    }
}
