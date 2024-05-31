using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Products.Queries.GetProductsByOrganization
{
    public class GetProductsByOrganizationQueryHandler
        : IRequestHandler<GetProductsByOrganizationQuery, List<Product>>
    {
        private readonly IProductRepository _repository;

        public GetProductsByOrganizationQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> Handle(GetProductsByOrganizationQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllByOrganizationId(
                request.IdRefOrganization, cancellationToken);
        }
    }
}
