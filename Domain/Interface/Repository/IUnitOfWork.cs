namespace Domain.Interface.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        void SaveChanges();
    }
}
