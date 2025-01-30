using hris.Staff.Application.Query._Employee;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace hris.Hubs
{
    public class EmployeeHub : Hub
    {
        private readonly IMediator _mediator;

        public EmployeeHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SearchEmployees(string searchTerm)
        {
            var query = new SearchEmployeeQuery(searchTerm);
            var result = await _mediator.Send(query);

            await Clients.All.SendAsync("ReceiveEmployees", result);
        }
    }
}
