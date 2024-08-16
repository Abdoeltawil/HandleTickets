using Application.Commands.Ticket;
using Application.Queries.Ticket;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HandleTickets.Controllers
{
    [ApiController]
    [Route("api/v1/Ticket")]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTickets")]
        public async Task<IActionResult> GetTickets([FromQuery] GetTicketsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("CreateTickets")]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
