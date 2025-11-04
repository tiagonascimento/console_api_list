using Bank.Domain;

namespace Bank.Aplication
{
    public interface IItenAplication
    {
        public Task<bool> CreateItem(Item itemObj);
        public Task<List<Item>> GetLatestPositionsByClient(string clientId);
        public Task<List<Item>> RetornUltimaPosiSumary(string clientId);
        public Task<List<Item>> RetorLastTop10();


    }
}
