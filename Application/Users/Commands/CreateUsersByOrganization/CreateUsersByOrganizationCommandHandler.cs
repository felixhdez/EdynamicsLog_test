using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Users.Commands.CreateUsersByOrganization
{
    internal class CreateUsersByOrganizationCommandHandler
        : IRequestHandler<CreateUsersByOrganizationCommand>
    {
        private readonly IUsersRepository _repository;

        public CreateUsersByOrganizationCommandHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateUsersByOrganizationCommand request,
            CancellationToken cancellationToken)
        {
            var users = GetRecords(request.IdOrganization);
            await _repository.SaveMultipleUsers(users, cancellationToken);
            return await Task.FromResult(Unit.Value);
        }

        private List<User> GetRecords(int organizationId)
        {
            return Enumerable.Range(1, 50).Select(u => new User
            {
                Email = $"user{organizationId}_{u}@gmail.com",
                Password = Guid.NewGuid().ToString(),
                OrganizationId = organizationId
            }).ToList();            
        }
    }
}
