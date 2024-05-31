using Application.Products.Commands.CreateProductsByOrganization;
using Application.Users.Commands.CreateUsersByOrganization;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Organizations.Commands.CreateNewOrganization
{
    public class CreateNewOrganizationCommandHandler : IRequestHandler<CreateNewOrganizationCommand>
    {
        private readonly IOrganizationsRepository _repository;
        private readonly IMediator _mediator;

        public CreateNewOrganizationCommandHandler(
            IOrganizationsRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateNewOrganizationCommand request,
            CancellationToken cancellationToken)
        {
            var organization = new Organization
            {
                Name = request.Name,
                SlugTenant = request.SlugTenant
            };
            await _repository.CreateNewOrganization(organization, cancellationToken);
            
            await _mediator.Send(
                new CreateUsersByOrganizationCommand(organization.Id), cancellationToken);
            await _mediator.Send(
                new CreateProductsByOrganizacionCommand(organization.Id), cancellationToken);
            return await Task.FromResult(Unit.Value);
        }
    }
}
