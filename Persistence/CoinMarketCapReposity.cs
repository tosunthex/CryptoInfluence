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
    public class CoinMarketCapReposity:ICoinMarketCap
    {
        private readonly IJsonDeserialize _jsonDeserialize;
        private readonly CoinTweetyDbContext _context;
        private readonly RestApiOptions _restApiOptions;
        
        public CoinMarketCapReposity(IOptions<MongoDbOptions> mongoDbSettings,
            IOptions<RestApiOptions> restApiOptions,
            IJsonDeserialize jsonDeserialize)
        {
            _jsonDeserialize = jsonDeserialize;
            _restApiOptions = restApiOptions.Value;
            _context = new CoinTweetyDbContext(mongoDbSettings);
        }

        public async Task<IEnumerable<CoinMarketCap>> GetAllCoinMarketCap()
        {
            return await _context.CoinMarketCapCollection.Find(_ => true).ToListAsync();
        }

        public async Task Add(CoinMarketCap coinMarketCap)
        {
            await _context.CoinMarketCapCollection.InsertOneAsync(coinMarketCap);
        }

        public async Task<CoinMarketCap> GetLastestBySymbol(string symbol)
        {
            return await _context.CoinMarketCapCollection.Find(cmc => cmc.symbol == symbol)
                .SortByDescending(cmc => cmc.RecordDate).Limit(1).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CoinMarketCap>> DeserializeJson(string limit)
        {
            var stringResult = await _jsonDeserialize.DeserializeJsonFromUrl($"{_restApiOptions.CoinMarketCapApi}/?limit={limit}");
            return JsonConvert.DeserializeObject<IEnumerable<CoinMarketCap>>(stringResult);
        }
    }
}