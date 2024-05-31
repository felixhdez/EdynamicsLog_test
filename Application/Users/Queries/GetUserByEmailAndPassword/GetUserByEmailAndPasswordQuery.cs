using MediatR;

namespace Application.Users.Queries.GetUserByEmailAndPassword
{
    public class GetUserByEmailAndPasswordQuery : IRequest<UserResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
