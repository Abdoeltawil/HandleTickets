using Infrastructure.Repository;
using MediatR;
using TicketEntity = Domain.Entities.Ticket;
namespace Application.Queries.Ticket
{
    public class GetTicketsQuery : IRequest<List<TicketEntity>>
    {
        public int PageSize { get; set; } = 5;
        public int PageIndex { get; set; } = 0;
    }
    public class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, List<TicketEntity>>
    {
        private readonly IBaseRepository<TicketEntity> _ticketRepository;

        public GetTicketsQueryHandler(IBaseRepository<TicketEntity> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<TicketEntity>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketRepository.GetAllAsync(request.PageSize,request.PageIndex);
            return tickets;
        }
    }
}
