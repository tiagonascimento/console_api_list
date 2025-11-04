using Bank.Domain;
using Microsoft.EntityFrameworkCore;


namespace Bank.Infra.repository.interfaces
{
    public interface IItenRepository
    {
        public Task AddItem(Item objItem);
        public   Task<List<Item>> GetLatestPositionsByClient(string clientId);
        public   Task<List<Item>> RetornUltimaPosiSumary(string clientId);
        public   Task<List<Item>> RetorLastTop10();
      
    }
}
