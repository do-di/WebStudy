using Domain.Entities;

namespace Domain.Interface.Repository
{
    public interface IStaticUserRepository
    {
        void Create(User user);
        List<User> GetAll();
    }
}
