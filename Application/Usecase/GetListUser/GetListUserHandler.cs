using Application.Models;
using AutoMapper;
using Domain.Interface.Repository;
using MediatR;

namespace Application.Usecase.GetListUser
{
    public class GetListUserHandler : IRequestHandler<GetListUserQuery, List<UserDto>>
    {
        private readonly IStaticUserRepository _staticUserRepository;
        private readonly IMapper mapper;
        public GetListUserHandler(IStaticUserRepository staticUserRepository, IMapper mapper)
        {
            this._staticUserRepository = staticUserRepository;
            this.mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            var users = _staticUserRepository.GetAll();
            var result = mapper.Map<List<UserDto>>(users);
            return result;
        }
    }
}
