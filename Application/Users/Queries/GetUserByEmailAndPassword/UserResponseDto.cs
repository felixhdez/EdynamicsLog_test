using Application.Organizations.Queries.GetOrganizationById;
using Application.Utils;
using Domain.Entities;

namespace Application.Users.Queries.GetUserByEmailAndPassword
{
    public class UserResponseDto : IMapFrom<User>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public OrganizationResponseDto Organization { get; set; }
    }
}
