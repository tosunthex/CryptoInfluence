using System.Collections.Generic;
using System.Threading.Tasks;
using cointweety.Core;
using cointweety.Core.Model;
using cointweety.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace cointweety.Persistence
{
    public class SolumeReposity:ISolume
    {
        private readonly CoinTweetyDbContext _context;
        private readonly RestApiOptions _restApiOptions;
        private readonly IJsonDeserialize _jsonDeserialize;

        public SolumeReposity(IOptions<MongoDbOptions> mongoSettings,
            IOptions<RestApiOptions> restApiOptions,
            IJsonDeserialize jsonDeserialize)
        {
            _restApiOptions = restApiOptions.Value;
            _jsonDeserialize = jsonDeserialize;
            _context = new CoinTweetyDbContext(mongoSettings);
        }
        public Task<IEnumerable<SolumeDetail>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task Add(SolumeDetail solumeDetail)
        {
            await _context.SolumeCollection.InsertOneAsync(solumeDetail);
            
        }

        public async Task<SolumeDetail> GetLastestBySymbol(string symbol)
        {
            return await _context.SolumeCollection.Find(sd => sd.Symbol == symbol).Limit(1)
                .SortByDescending(sd => sd.RecordDate).FirstOrDefaultAsync();
        }

        public async Task<Dictionary<string, SolumeDetail>> DeserializeJson(string symbol)
        {
            var stringResult = await _jsonDeserialize.DeserializeJsonFromUrl($"{_restApiOptions.SolumeApi}");
            return JsonConvert.DeserializeObject<Dictionary<string, SolumeDetail>>(stringResult);
        }
    }
}