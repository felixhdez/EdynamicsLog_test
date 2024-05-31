using Application.Organizations.Queries.GetOrganizationBySlug;
using Application.Products.Commands.CreateNewProductByOrganization;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Products.Commands.CreateNewProduct
{
    public class CreateNewProductCommandHandler : IRequestHandler<CreateNewProductCommand>
    {        
        private readonly IMediator _mediator;

        public CreateNewProductCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateNewProductCommand request,
            CancellationToken cancellationToken)
        {
            var organization = await _mediator.Send(
                new GetOrganizationBySlugQuery(request.SlugTenant), cancellationToken);

            if (organization is null)
                throw new ValidationException("Organización no encontrada");

            await _mediator.Send(new CreateNewProductByOrganizationCommand
            {
                Name = request.Name,
                Description = request.Description,
                Duration = request.Duration,
                OrganizationId = organization.Id
            });

            return await Task.FromResult(Unit.Value);
        }
    }
}
