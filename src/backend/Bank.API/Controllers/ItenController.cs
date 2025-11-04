using Bank.Aplication;
using Bank.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Controllers
{
    [Route("api/positions")]
    [ApiController]
    public class ItenController : ControllerBase
    {
    

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetLatestPositionsByClient(string clientId, IItenAplication ItenAplication)
        {

            var result = await ItenAplication.GetLatestPositionsByClient(clientId);

           return Ok(result);
        }
        [HttpGet("client/{clientId}/summary")]
        public async Task<IActionResult> GetSummaryByClient(string clientId, IItenAplication ItenAplication)
        {

            var result = await ItenAplication.RetornUltimaPosiSumary(clientId);


            var somaPorProduto = result
             .GroupBy(p => p.productId)
             .Select(g => new {
                 ProductId = g.Key,
                 SomaValor = g.Sum(p => p.value),
                 SomaQuantidade = g.Sum(p => p.quantity)
             })
             .ToList();

            return Ok(somaPorProduto);
        }
        [HttpGet("top10")]
        public async Task<IActionResult> GetTop10Positions(IItenAplication ItenAplication)
        {

            var result = await ItenAplication.RetorLastTop10();
            return Ok(result);
        }



    }
}
