using System.Threading.Tasks;
using cointweety.Core;
using cointweety.Core.Model;
using cointweety.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace cointweety.Persistence
{
    public class SocialStatsReposity:ISocialStats
    {
        private readonly IJsonDeserialize _jsonDeserialize;
        private readonly RestApiOptions _restApiOptions;
        
        public SocialStatsReposity(IJsonDeserialize jsonDeserialize, IOptions<RestApiOptions> restApiOptions)
        {
            _jsonDeserialize = jsonDeserialize;
            _restApiOptions = restApiOptions.Value;
        }
        public async Task<SocialStats> GetById(string Id)
        {
            var stringResult =
                await _jsonDeserialize.DeserializeJsonFromUrl(
                    $"{_restApiOptions.CryptoCompareApiOld}/api/data/socialstats/?id={Id}");
            return JsonConvert.DeserializeObject<SocialStatsData>(stringResult).Data;
        }
    }
}