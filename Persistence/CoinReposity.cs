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
    public class CoinReposity:ICoin
    {
        
        private readonly IJsonDeserialize _jsonDeserialize;
        private readonly CoinTweetyDbContext _context;
        private readonly RestApiOptions _restApiOptions;
        
        public CoinReposity(IOptions<MongoDbOptions> mongoDbOptions,
            IOptions<RestApiOptions> restApiOptions,
            IJsonDeserialize jsonDeserialize)
        {
            _restApiOptions = restApiOptions.Value;
            _jsonDeserialize = jsonDeserialize;
            _context = new CoinTweetyDbContext(mongoDbOptions);
        }
        
        public void Add(Coin coin)
        {
            _context.Coin.InsertOneAsync(coin);
        }

        public async Task<CoinData> DeseriliazeJson()
        {
            var stringResult = await _jsonDeserialize.DeserializeJsonFromUrl($"{_restApiOptions.CryptoCompareApi}/data/all/coinlist");
            return JsonConvert.DeserializeObject<CoinData>(stringResult);
        }

        public async Task<IEnumerable<Coin>> GetAll()
        {
            return await _context.Coin.Find(c => true).ToListAsync();
        }

        public async Task<Coin> GetBySymbol(string symbol)
        {
            return await _context.Coin.Find(c => c.Symbol == symbol).FirstOrDefaultAsync();
        }
    }
}