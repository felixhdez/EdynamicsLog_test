using Application.Utils;
using Domain.Entities;

namespace Application.Products.Queries.GetProductsByTenant
{
    public class ProductResponseDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
    }
}
