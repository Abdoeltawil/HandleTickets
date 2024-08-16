using Infrastructure.UnitOfWork;
using MediatR;
using TicketEntity = Domain.Entities.Ticket;

namespace Application.Commands.Ticket
{
    public class CreateTicketCommand : IRequest<int>
    {
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await TicketEntity.CreateTicket(request.PhoneNumber, request.Governorate, request.City, request.District);
            await _unitOfWork.TicketRepository.AddAsync(ticket);
            await _unitOfWork.CommitAsync();
            return ticket.Id;
        }
    }
}
