using System;
using System.Threading.Tasks;
using cointweety.Core;
using Microsoft.AspNetCore.Mvc;


namespace cointweety.Controllers
{
    [Route("api/[controller]")]
    public class CoinController:Controller
    {
        private readonly ICoin _coin;
        private readonly ISocialStats _socialStats;

        public CoinController(ICoin coin, ISocialStats socialStats)
        {
            _coin = coin;
            _socialStats = socialStats;
        }
        
        [HttpPut]
        public async Task<IActionResult> SetCoinDetail()
        {
            var rawCoinDatas = await _coin.DeseriliazeJson();
            
            if (rawCoinDatas == null) return BadRequest();

            var recordDate = DateTime.Now;
            foreach (var coinData in rawCoinDatas.Data)
            {
                //coinData.Value.SocialStats = await _socialStats.GetById(coinData.Value.Id);
                coinData.Value.RecordDate = recordDate;
                _coin.Add(coinData.Value);
            }
            return Ok();
        }

        
        [HttpGet]
        public async Task<IActionResult> GetCoinDetail(string symbol)
        {
            return Json(await _coin.GetBySymbol(symbol));
        }
        
    }

    
}