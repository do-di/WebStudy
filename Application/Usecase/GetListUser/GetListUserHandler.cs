using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interface.Cache;
using Domain.Interface.Repository;
using MediatR;

namespace Application.Usecase.GetListUser
{
    public class GetListUserHandler : IRequestHandler<GetListUserQuery, List<UserDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IRedisCache redisCache;
        public GetListUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IRedisCache redisCache)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.redisCache = redisCache;
        }
        public async Task<List<UserDto>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            var users = redisCache.GetData<IEnumerable<UserEntity>>("users");
            if (users == null)
            {
                users = await unitOfWork.UserRepository.GetAll().ConfigureAwait(false);
                redisCache.SetData<IEnumerable<UserEntity>>("users", users, DateTimeOffset.UtcNow.AddMinutes(5));
            }
            var result = mapper.Map<List<UserDto>>(users);
            return result;
        }
    }
}
