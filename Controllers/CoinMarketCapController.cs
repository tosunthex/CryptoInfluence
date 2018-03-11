using System;
using System.Threading.Tasks;
using cointweety.Core;
using Microsoft.AspNetCore.Mvc;

namespace cointweety.Controllers
{
    [Route("api/[controller]")]
    public class CoinMarketCapController:Controller
    {
        private readonly ICoinMarketCap _coinMarketCap;

        public CoinMarketCapController(ICoinMarketCap coinMarketCap)
        {
            _coinMarketCap = coinMarketCap;
        }
        [HttpGet]
        public async Task<IActionResult> GetTopCoins(string limit=null)
        {
            var dateTimeNow = DateTime.Now;
            
            var rawCoins = await _coinMarketCap.DeserializeJson(limit);
            
            if (rawCoins == null) return BadRequest();
            
            foreach (var coin in rawCoins)
            {
                coin.RecordDate = dateTimeNow;
                await _coinMarketCap.Add(coin);
            }

            return Ok();
            
            
        }
    }
}