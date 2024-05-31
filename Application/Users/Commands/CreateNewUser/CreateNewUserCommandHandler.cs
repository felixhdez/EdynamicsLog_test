using Application.Organizations.Queries.GetOrganizationById;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Users.Commands.CreateNewUser
{
    public class CreateNewUserCommandHandler : IRequestHandler<CreateNewUserCommand>
    {
        private readonly IUsersRepository _repository;
        private readonly IMediator _mediator;

        public CreateNewUserCommandHandler(IUsersRepository repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateNewUserCommand request,
            CancellationToken cancellationToken)
        {
            var organization = await _mediator.Send(
                new GetOrganizationByIdQuery(request.OrganizationId), cancellationToken);

            if (organization is null) 
                throw new ValidationException("No existe la Organización a la que se intenta asociar el usuario");

            var newUser = new User
            {
                Email = request.Email,
                Password = request.Password,
                OrganizationId = request.OrganizationId
            };

            await _repository.CreateUser(newUser, cancellationToken);
            return await Task.FromResult(Unit.Value);
        }
    }
}
