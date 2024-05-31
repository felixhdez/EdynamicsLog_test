using Application.Utils.Behaviors.Interfaces;
using MediatR;

namespace Application.Products.Queries.GetProductsByTenant
{
    public class GetProductsByTenantQuery : ITenantBehavior<List<ProductResponseDto>>
    {
        public string SlugTenant { get; set; }
    }
}
