using hris.Seed.Application.Query._Department;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace hris.Hubs
{
    public class DepartmentHub : Hub
    {
        private readonly IMediator _mediator;

        public DepartmentHub(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task SearchDepartments(string searchTerm)
        {
            var query = new SearchDepartmentsQuery(searchTerm);
            var result = await _mediator.Send(query);

            await Clients.All.SendAsync("ReceiveDepartments", result);
        }
    }
}
