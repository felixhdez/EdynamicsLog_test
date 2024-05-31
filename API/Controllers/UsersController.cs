using Application.Users.Commands.CreateNewUser;
using Application.Users.Commands.GenerateJwtTokenByUser;
using Application.Users.Queries.GetUserByEmailAndPassword;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(GetUserByEmailAndPasswordQuery request)
        {
            var user = await _mediator.Send(request);
            if (user is null)
                return Unauthorized();

            var token = await _mediator.Send(new GenerateJwtTokenCommand(user.Email));
            return Ok(new { accessToken = token, tenant = user.Organization.SlugTenant });
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> CreateUser(CreateNewUserCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
