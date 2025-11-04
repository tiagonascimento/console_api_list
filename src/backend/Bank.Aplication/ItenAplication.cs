
using Bank.Domain;
using Bank.Infra.repository;
using Bank.Infra.repository.interfaces;
using System.Threading.Tasks;

namespace Bank.Aplication
{
    public class ItenAplication: IItenAplication
    {
        private readonly IItenRepository _IItenRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ItenAplication(IItenRepository IItenRepository, IUnitOfWork unitOfWork)
        {
            _IItenRepository = IItenRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateItem(Item itemObj)
        {                       
            await _IItenRepository.AddItem(itemObj);
            await _unitOfWork.Commit();
            return true;
        }
        public async Task<List<Item>> GetLatestPositionsByClient(string client)
        {
            return await _IItenRepository.GetLatestPositionsByClient(client);
        }
        public async Task<List<Item>> RetornUltimaPosiSumary(string clientId)
        {
            return await _IItenRepository.RetornUltimaPosiSumary(clientId);

        }

        public async Task<List<Item>> RetorLastTop10()
        {
             var latestPositions = await _IItenRepository.RetorLastTop10();

            var summary = latestPositions
                    .GroupBy(p => p.positionId)
                    .Select(g => new
                    {
                        ProductId = g.Key,
                        TotalValue = g.Sum(p => p.value),
                        TotalQuantity = g.Sum(p => p.quantity)
                    });


            return latestPositions;
        }

        
            
            
    }
}
