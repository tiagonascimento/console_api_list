
using Bank.Domain;
using Bank.Infra.repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infra.repository
{
    public class ItenRepository:IItenRepository
    {
        private readonly BankDbContext _dbContext;
        public ItenRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddItem(Item objItem)
        {
            await _dbContext.Itens.AddAsync(objItem);
        }

        public async Task<List<Item>>GetLatestPositionsByClient(string clientId)
        {

            return (await _dbContext.Itens
                                            .Where(p => p.clientId == clientId)
                                            .ToListAsync())
                                            .GroupBy(p => p.positionId)
                                            .Select(g => g.OrderByDescending(p => p.date).First())
                                            .OrderByDescending(p => p.date)
                                            .ToList();


           
        }
        public async Task<List<Item>> RetornUltimaPosiSumary(string clientId)
        {
            return (await _dbContext.Itens
                    .Where(p => p.clientId == clientId)
                    .ToListAsync())
                    .GroupBy(p => p.positionId)
                    .Select(g => g.OrderByDescending(p => p.date).First())
                    .ToList(); // ainda é List<Item>



        }
        public async Task<List<Item>> RetorLastTop10()
        {
           return await _dbContext.Itens
                               .OrderByDescending(p => p.value)
                               .Take(10)
                               .ToListAsync();


        }

    }
}
