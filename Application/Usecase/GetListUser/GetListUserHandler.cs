using Application.Models;
using AutoMapper;
using Domain.Interface.Repository;
using MediatR;

namespace Application.Usecase.GetListUser
{
    public class GetListUserHandler : IRequestHandler<GetListUserQuery, List<UserDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetListUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            var users = await unitOfWork.UserRepository.GetAll().ConfigureAwait(false);
            var result = mapper.Map<List<UserDto>>(users);
            return result;
        }
    }
}
