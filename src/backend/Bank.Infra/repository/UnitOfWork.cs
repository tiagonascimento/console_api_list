
using Bank.Infra.repository.interfaces;

namespace Bank.Infra.repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BankDbContext _dbcontex;
        public UnitOfWork(BankDbContext dbContex) => _dbcontex = dbContex;

        public async Task Commit() => await _dbcontex.SaveChangesAsync();
    }
}
