using Domain.Entities;
using Domain.Interface.Repository;

namespace Infrastructure.Repository
{
    public class StaticUserRepository : IStaticUserRepository
    {
        private static List<User> _users = new List<User>();

        public void Create(User user)
        {
            _users.Add(user);
        }

        public List<User> GetAll()
        {
            return _users;
        }
    }
}
