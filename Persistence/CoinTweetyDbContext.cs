using cointweety.Core.Model;
using cointweety.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace cointweety.Persistence
{
    public class CoinTweetyDbContext
    {
        private IMongoDatabase _database = null;

        public CoinTweetyDbContext(IOptions<MongoDbOptions> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            _database = client.GetDatabase(mongoDbSettings.Value.Database);
        }

        public IMongoCollection<CoinMarketCap> CoinMarketCapCollection =>
            _database.GetCollection<CoinMarketCap>("CoinMarketCap");

        public IMongoCollection<SolumeDetail> SolumeCollection =>
            _database.GetCollection<SolumeDetail>("SolumeDetail");

        public IMongoCollection<CoinSocialAnalysis> CoinSocialAnalysisCollection =>
            _database.GetCollection<CoinSocialAnalysis>("CoinSocialAnalysis");
        
        public IMongoCollection<CoinSocialMediaAddress> CoinSocialMediaAddress =>
            _database.GetCollection<CoinSocialMediaAddress>("CoinSocialMediaAddress");

        public IMongoCollection<CoinTweet> CoinTweet =>
            _database.GetCollection<CoinTweet>("CoinTweet");

        public IMongoCollection<Coin> Coin => _database.GetCollection<Coin>("Coin");
    }
}