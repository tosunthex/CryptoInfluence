using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cointweety.Core.Model
{
    public class CoinMarketCap
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        [BsonRequired]
        public string id { get; set; }
        [BsonRequired]
        public string name { get; set; }
        [BsonRequired]
        public string symbol { get; set; }
        public int rank { get; set; }
        public string price_usd { get; set; }
        public string price_btc { get; set; }
        public string daily_volume_usd { get; set; }
        public string market_cap_usd { get; set; }
        public string available_supply { get; set; }
        public string total_supply { get; set; }
        public string max_supply { get; set; }
        public double percent_change_1h { get; set; }
        public double percent_change_24h { get; set; }
        public double percent_change_7d { get; set; }
        public string last_updated { get; set; }
        public DateTime RecordDate { get; set; }
    }
}