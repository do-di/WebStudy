using Domain.Entities;
using Domain.Interface.Repository;
using MediatR;

namespace Application.Usecase.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IStaticUserRepository _staticUserRepository;
        public CreateUserHandler(IStaticUserRepository staticUserRepository)
        {
            this._staticUserRepository = staticUserRepository;
        }

        public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _staticUserRepository.Create(new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Email = request.Email,
                HashedPassword = request.Password,
            });
            return Task.CompletedTask;
        }
    }
}
