using System.Threading.Tasks;
using cointweety.Core;
using cointweety.Core.Model;
using cointweety.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace cointweety.Persistence
{
    public class CoinSocialMediaAddressReposity:ICoinSocialMediaAddress
    {
        private readonly CoinTweetyDbContext _context;

        public CoinSocialMediaAddressReposity(IOptions<MongoDbOptions> mongoDbSettings)
        {
            _context = new CoinTweetyDbContext(mongoDbSettings);
        }
        public async Task<CoinSocialMediaAddress> GetBySymbol(string symbol)
        {
            return await _context.CoinSocialMediaAddress.Find(csma => csma.Symbol == symbol).FirstOrDefaultAsync();
        }

        public async Task<CoinSocialMediaAddress> GetByTwitterScreenName(string screenName)
        {
            return await _context.CoinSocialMediaAddress.Find(csma => csma.TwitterAddress == screenName).FirstOrDefaultAsync();
        }
    }
}