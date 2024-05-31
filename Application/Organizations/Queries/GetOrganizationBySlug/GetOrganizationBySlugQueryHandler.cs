using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Organizations.Queries.GetOrganizationBySlug
{
    public class GetOrganizationBySlugQueryHandler
        : IRequestHandler<GetOrganizationBySlugQuery, Organization>
    {
        private readonly IOrganizationsRepository _repository;

        public GetOrganizationBySlugQueryHandler(IOrganizationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Organization> Handle(GetOrganizationBySlugQuery request, CancellationToken cancellationToken)
        {
            var organization =
                await _repository.GetBySlug(request.SlugTenant, cancellationToken);

            return organization;
        }
    }
}
