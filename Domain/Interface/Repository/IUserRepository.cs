using Domain.Entities;

namespace Domain.Interface.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task Create(UserEntity user);
        Task<List<UserEntity>> GetAll();
    }
}
