using Domain.Entities;

namespace Domain.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
    }
}
