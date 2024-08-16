namespace Infrastructure.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        List<T?> GetAll();
        T? GetById(int id);
        void Add(T item);
        Task AddAsync(T item);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(int pageSize, int pageIndex);
        Task<T?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
