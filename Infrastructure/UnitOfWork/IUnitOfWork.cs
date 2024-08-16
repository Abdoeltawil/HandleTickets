using Domain.Entities;
using Infrastructure.Repository;
namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IBaseRepository<Ticket> TicketRepository{ get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
