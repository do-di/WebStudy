using Domain.Entities;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext context;
        private static List<User> _users = new List<User>();

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        //public async Task Create(User user)
        //{
        //    await context.Users.AddAsync(user);
        //}

        public void Create(User user)
        {
            _users.Add(user);
        }

        //public Task<List<User>> GetAll()
        //{
        //    return context.Users.ToListAsync();
        //}

        public List<User> GetAll()
        {
            return _users;
        }
    }
}
