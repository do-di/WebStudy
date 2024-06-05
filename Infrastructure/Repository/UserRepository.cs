using Domain.Entities;

namespace Infrastructure.Repository
{
    public class UserRepository : Repository<UserEntity>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
