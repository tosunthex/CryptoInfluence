using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cointweety.Core.Model
{
    public class CoinTweet
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        public string TweetId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int FavoriteCount { get; set; }
        public string ProfileImageUrl { get; set; }
        public int RetweetCount { get; set; }
        public string ScreenName { get; set; }
        public string Text { get; set; }
        public string TweetURL { get; set; }
        public string Name { get; set; }
        public CoinSocialMediaAddress SocialMediaAddress { get; set; }
    }
}