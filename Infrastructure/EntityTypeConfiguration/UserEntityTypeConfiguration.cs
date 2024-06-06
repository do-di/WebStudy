using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfiguration;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToContainer("User");
        builder.HasKey(x => x.Id);
        builder.HasPartitionKey(e => e.Id);
        builder.Property(e => e.Id).ToJsonProperty("id");
        builder.Property(e => e.UserName).ToJsonProperty("username");
        builder.Property(e => e.Email).ToJsonProperty("email");
        builder.Property(e => e.HashedPassword).ToJsonProperty("hashedPassword");
    }
}