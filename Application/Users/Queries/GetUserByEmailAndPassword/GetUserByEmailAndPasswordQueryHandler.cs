using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Users.Queries.GetUserByEmailAndPassword
{
    public class GetUserByEmailAndPasswordQueryHandler
        : IRequestHandler<GetUserByEmailAndPasswordQuery, UserResponseDto>
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByEmailAndPasswordQueryHandler(
            IUsersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> Handle(GetUserByEmailAndPasswordQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByEmailAndPassword(
                request.Email, request.Password, cancellationToken);

            return _mapper.Map<User, UserResponseDto>(user);
        }
    }
}
