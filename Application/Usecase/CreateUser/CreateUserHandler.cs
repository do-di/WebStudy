using Domain.Entities;
using Domain.Interface.Repository;
using MediatR;

namespace Application.Usecase.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            unitOfWork.UserRepository.Create(new UserEntity()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Email = request.Email,
                HashedPassword = request.Password,
            });
            unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
