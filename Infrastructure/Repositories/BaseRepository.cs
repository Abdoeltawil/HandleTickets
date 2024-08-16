
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DatabaseContext _dbContext;

        public BaseRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T item)
        => _dbContext.Add(item);

        public List<T> GetAll()
        => _dbContext.Set<T>().ToList();

        public T? GetById(int id)
        => _dbContext.Set<T>().Find(id);

        public async Task AddAsync(T item)
        => await _dbContext.AddAsync(item);

        public async Task<List<T>> GetAllAsync()
        => await _dbContext.Set<T>().ToListAsync();
        public async Task<List<T>> GetAllAsync(int pageSize, int pageIndex)
        => await _dbContext.Set<T>().Skip(pageIndex*pageSize).Take(pageSize).ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
        => await _dbContext.Set<T>().FindAsync(id);

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity is not null)
            {
                _dbContext.Set<T>().Remove(entity);
            }
        }
    }
}
