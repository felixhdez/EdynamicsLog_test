using Application.Utils;
using Domain.Entities;

namespace Application.Organizations.Queries.GetOrganizationById
{
    public class OrganizationResponseDto : IMapFrom<Organization>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SlugTenant { get; set; }
    }
}
