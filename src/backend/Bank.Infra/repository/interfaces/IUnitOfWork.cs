

namespace Bank.Infra.repository.interfaces
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
