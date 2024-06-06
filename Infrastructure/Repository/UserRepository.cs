using Domain.Entities;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task Create(UserEntity user)
        {
            await context.Users.AddAsync(user);
        }

        public Task<List<UserEntity>> GetAll()
        {
            return context.Users.ToListAsync();
        }
    }
}
