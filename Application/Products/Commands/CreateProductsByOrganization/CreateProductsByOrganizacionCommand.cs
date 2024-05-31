using MediatR;

namespace Application.Products.Commands.CreateProductsByOrganization
{
    public class CreateProductsByOrganizacionCommand : IRequest
    {
        public int IdOrganization { get; set; }

        public CreateProductsByOrganizacionCommand(int idOrganization)
        {
            IdOrganization = idOrganization;
        }
    }
}
