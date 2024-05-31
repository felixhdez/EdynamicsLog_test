using Application.Organizations.Commands.CreateNewOrganization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrganizationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> CreateOrganization(
            CreateNewOrganizationCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
