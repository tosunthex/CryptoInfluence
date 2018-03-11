using System;
using System.Threading.Tasks;
using cointweety.Core;
using Microsoft.AspNetCore.Mvc;

namespace cointweety.Controllers
{
    [Route("api/[controller]")]
    public class SolumeController : Controller
    {
        private readonly ISolume _solume;

        public SolumeController(ISolume solume)
        {
            _solume = solume;
        }
        
        [HttpPut]
        public async Task<IActionResult> GetSolumeDetail(string symbol)
        {
            var dateTimeNow = DateTime.Now;
            
            var rawSolumeString = await _solume.DeserializeJson(symbol);
            
            if (rawSolumeString == null) return BadRequest();
            
            foreach (var solumeDetail in rawSolumeString)
            {
                solumeDetail.Value.RecordDate = dateTimeNow;
                await _solume.Add(solumeDetail.Value);
            }

            return Ok();
        }
        
    }
}