using MediatR;

namespace Application.Organizations.Queries.GetOrganizationById
{
    public class GetOrganizationByIdQuery : IRequest<OrganizationResponseDto>
    {
        public int IdOrganization { get; set; }

        public GetOrganizationByIdQuery(int idOrganization)
        {
            IdOrganization = idOrganization;
        }
    }
}
