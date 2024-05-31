using MediatR;

namespace Application.Products.Commands.CreateNewProductByOrganization
{
    public class CreateNewProductByOrganizationCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public int OrganizationId { get; set; }
    }
}
