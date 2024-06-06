using Domain.Entities;
using Domain.Interface.Repository;

namespace Infrastructure.Repository
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
