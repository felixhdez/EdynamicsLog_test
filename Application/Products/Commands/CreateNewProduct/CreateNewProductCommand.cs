using Application.Utils.Behaviors.Interfaces;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Products.Commands.CreateNewProduct
{
    public class CreateNewProductCommand : ITenantBehavior<Unit>
    {
        [JsonIgnore]
        public string? SlugTenant { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
    }
}
