using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
