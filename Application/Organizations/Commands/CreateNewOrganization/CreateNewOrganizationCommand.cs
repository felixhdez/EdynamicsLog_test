using MediatR;

namespace Application.Organizations.Commands.CreateNewOrganization
{
    public class CreateNewOrganizationCommand : IRequest
    {
        public string Name { get; set; }
        public string SlugTenant { get; set; }
    }
}
