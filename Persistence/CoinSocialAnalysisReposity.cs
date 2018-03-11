using System.Collections.Generic;
using System.Threading.Tasks;
using cointweety.Core;
using cointweety.Core.Model;
using cointweety.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace cointweety.Persistence
{
    public class CoinSocialAnalysisReposity:ICoinSocialAnalysis
    {
        private readonly CoinTweetyDbContext _context;

        public CoinSocialAnalysisReposity(IOptions<MongoDbOptions> mongoDbSettings)
        {
            _context = new CoinTweetyDbContext(mongoDbSettings);
        }
        public async Task Add(CoinSocialAnalysis coinSocialAnalysis)
        {
            await _context.CoinSocialAnalysisCollection.InsertOneAsync(coinSocialAnalysis);
        }

        public async Task<IEnumerable<CoinSocialAnalysis>> GetAll()
        {
            return await _context.CoinSocialAnalysisCollection.Find(csa => true).ToListAsync();
        }
    }
}