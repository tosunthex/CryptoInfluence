namespace cointweety.Core.Model
{
    public class CoinSocialAnalysis
    {
        //[BsonId]
        //public ObjectId ObjectId { get; set; }
        public CoinMarketCap CoinMarketCap { get; set; }
        public SolumeDetail SolumeDetail { get; set; }
        public CoinTweet CoinTweet { get; set; }
        public Coin Coin { get; set; }
    }
}