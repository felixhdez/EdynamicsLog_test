using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Products.Commands.CreateProductsByOrganization
{
    public class CreateProductsByOrganizacionCommandHandler
        : IRequestHandler<CreateProductsByOrganizacionCommand>
    {
        private readonly IProductRepository _repository;

        public CreateProductsByOrganizacionCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductsByOrganizacionCommand request,
            CancellationToken cancellationToken)
        {
            var products = GetRecords(request.IdOrganization);
            await _repository.SaveMultipleUsers(products, cancellationToken);
            return await Task.FromResult(Unit.Value);
        }

        private List<Product> GetRecords(int organizationId)
        {
            var random = new Random();
            return Enumerable.Range(1, 50).Select(u => new Product
            {
                Name = $"product{organizationId}_{u}",
                Description = Guid.NewGuid().ToString(),
                Duration = Math.Round(random.NextDouble()*10, 1),
                IdRefOrganization = organizationId
            }).ToList();
        }
    }
}
