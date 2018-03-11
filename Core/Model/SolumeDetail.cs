using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cointweety.Core.Model
{
    public class SolumeDetail
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        public double Change_24h { get; set; }
        public string Name { get; set; }
        public double Reddit_Change_24h { get; set; }
        public int Reddit_Volume_24h { get; set; }
        public int Sentiment_24h { get; set; }
        public double Sentiment_Change_24h { get; set; }
        public string Symbol { get; set; }
        public int Timestamp { get; set; }
        public double Twitter_Change_24h { get; set; }
        public int Twitter_Volume_24h { get; set; }
        public int Volume_24h { get; set; }
        public DateTime RecordDate { get; set; }
    }
        
    
}