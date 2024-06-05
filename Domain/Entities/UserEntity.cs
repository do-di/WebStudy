﻿namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;

        public string HashedPassword { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
