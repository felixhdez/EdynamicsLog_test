using MediatR;

namespace Application.Users.Commands.GenerateJwtTokenByUser
{
    public class GenerateJwtTokenCommand : IRequest<string>
    {
        public string UserName { get; set; }

        public GenerateJwtTokenCommand(string userName)
        {
            UserName = userName;
        }
    }
}
