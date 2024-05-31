using Application.Organizations.Queries.GetOrganizationBySlug;
using Application.Products.Queries.GetProductsByOrganization;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Products.Queries.GetProductsByTenant
{
    public class GetProductsByTenantQueryHandler
        : IRequestHandler<GetProductsByTenantQuery, List<ProductResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetProductsByTenantQueryHandler(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<List<ProductResponseDto>> Handle(GetProductsByTenantQuery request,
            CancellationToken cancellationToken)
        {
            var organization = await _mediator.Send(
                new GetOrganizationBySlugQuery(request.SlugTenant), cancellationToken);

            if (organization is null)
                throw new ValidationException("Organización no encontrada");

            var products = await _mediator.Send(new GetProductsByOrganizationQuery(organization.Id),
                cancellationToken);

            return _mapper.Map<List<Product>, List<ProductResponseDto>>(products);
        }
    }
}
