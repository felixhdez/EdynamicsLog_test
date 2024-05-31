using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Organizations.Queries.GetOrganizationById
{
    public class GetOrganizationByIdQueryHandler
        : IRequestHandler<GetOrganizationByIdQuery, OrganizationResponseDto>
    {
        private readonly IOrganizationsRepository _repository;
        private readonly IMapper _mapper;

        public GetOrganizationByIdQueryHandler(IOrganizationsRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrganizationResponseDto> Handle(GetOrganizationByIdQuery request,
            CancellationToken cancellationToken)
        {
            var organization = await _repository.GetById(request.IdOrganization);
            return _mapper.Map<Organization, OrganizationResponseDto> (organization);
        }
    }
}
