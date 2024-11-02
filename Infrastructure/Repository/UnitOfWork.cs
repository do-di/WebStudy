using Domain.Entities;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IUserRepository UserRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            UserRepository = new UserRepository(context);
        }

        public UnitOfWork()
        {
            this.context = new ApplicationDbContext(null);
            UserRepository = new UserRepository(context);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
