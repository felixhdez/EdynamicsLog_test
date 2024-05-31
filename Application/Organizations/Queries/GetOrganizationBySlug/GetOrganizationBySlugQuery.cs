using Domain.Entities;
using MediatR;

namespace Application.Organizations.Queries.GetOrganizationBySlug
{
    public class GetOrganizationBySlugQuery : IRequest<Organization>
    {
        public string SlugTenant { get; set; }

        public GetOrganizationBySlugQuery(string slugTenant)
        {
            SlugTenant = slugTenant;
        }
    }
}
