using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Products.Commands.CreateNewProductByOrganization
{
    public class CreateNewProductByOrganizationCommandHandler
        : IRequestHandler<CreateNewProductByOrganizationCommand>
    {
        private readonly IProductRepository _repository;

        public CreateNewProductByOrganizationCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateNewProductByOrganizationCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Duration = request.Duration,
                Description = request.Description,
                IdRefOrganization = request.OrganizationId
            };
            await _repository.CreateNewProduct(product, cancellationToken);
            return await Task.FromResult(Unit.Value);
        }
    }
}
