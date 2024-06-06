using Domain.Interface.Repository;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private readonly IUserRepository users;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            this.users = new UserRepository(context);
        }
    }
}
