using System.Collections.Generic;
using System.Threading.Tasks;
using cointweety.Core;
using cointweety.Core.Model;
using cointweety.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace cointweety.Persistence
{
    public class CoinTweetReposity:ICoinTweet
    {
        private readonly CoinTweetyDbContext _context;

        public CoinTweetReposity(IOptions<MongoDbOptions> mongoDbSettings)
        {
            _context = new CoinTweetyDbContext(mongoDbSettings);
        }
        
        public void Add(CoinTweet coinTweet)
        {
            _context.CoinTweet.InsertOneAsync(coinTweet);
        }

        public async Task<IEnumerable<CoinTweet>> GetAll()
        {
            return await _context.CoinTweet.Find(CT => true).ToListAsync();
        } 
    }
}