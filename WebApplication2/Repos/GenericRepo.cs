using Microsoft.EntityFrameworkCore;
using WebApplication2.IRepos;
using WebApplication2.Models;

namespace WebApplication2.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        readonly AppDbContext _db;
        readonly DbSet<T> _dbSet;
        public GenericRepo(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();  
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
