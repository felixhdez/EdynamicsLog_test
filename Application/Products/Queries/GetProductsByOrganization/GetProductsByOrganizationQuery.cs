using Domain.Entities;
using MediatR;

namespace Application.Products.Queries.GetProductsByOrganization
{
    public class GetProductsByOrganizationQuery : IRequest<List<Product>>
    {
        public int IdRefOrganization { get; set; }

        public GetProductsByOrganizationQuery(int idRefOrganization)
        {
            IdRefOrganization = idRefOrganization;
        }
    }
}
