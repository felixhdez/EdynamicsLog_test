using MediatR;

namespace Application.Users.Commands.CreateUsersByOrganization
{
    public class CreateUsersByOrganizationCommand : IRequest
    {
        public int IdOrganization { get; set; }

        public CreateUsersByOrganizationCommand(int idOrganization)
        {
            IdOrganization = idOrganization;
        }
    }
}
