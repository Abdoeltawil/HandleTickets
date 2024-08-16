using Domain.Entities;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        public IBaseRepository<Ticket> TicketRepository { get; private set; }
        public UnitOfWork(DatabaseContext databaseContext, IBaseRepository<Ticket> ticketRepository)
        {
            _databaseContext = databaseContext;
            TicketRepository = ticketRepository;
        }

        public int Commit()
        => _databaseContext.SaveChanges();

        public async Task<int> CommitAsync()
        => await _databaseContext.SaveChangesAsync();

        public void Dispose()
        => _databaseContext.Dispose();

        public async ValueTask DisposeAsync()
        => await _databaseContext.DisposeAsync();
    }
}
