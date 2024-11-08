﻿using Domain.Entities;

namespace Domain.Interface.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        void Create(User user);
        List<User> GetAll();
    }
}
