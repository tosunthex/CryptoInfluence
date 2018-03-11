using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cointweety.Core.Model
{
    public class CoinSocialMediaAddress
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Symbol { get; set; }

        public string TwitterAddress { get; set; }

        public string RedditAddress { get; set; }
    }
}