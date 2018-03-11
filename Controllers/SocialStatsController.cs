using System;
using System.Threading.Tasks;
using cointweety.Core;
using Microsoft.AspNetCore.Mvc;

namespace cointweety.Controllers
{
    [Route("api/[controller]")]
    public class SocialStatsController : Controller
    {
        private readonly ISocialStats _socialStats;
        public SocialStatsController(ISocialStats socialStats)
        {
            _socialStats = socialStats;
        }
        // GET
        [HttpPut]
        public async Task<IActionResult> SetCoinSocialDetail()
        {
            var recordDate = DateTime.Now;
            var aaa = await _socialStats.GetById("4321");
            return Ok();
        }
    }
}