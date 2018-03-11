using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace cointweety.Core.Model
{
    public class Coin
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string CoinName { get; set; }
        public string FullName { get; set; }
        public string Algorithm { get; set; }
        public string ProofType { get; set; }
        public string FullyPremined { get; set; }
        public string TotalCoinSupply { get; set; }
        public string PreMinedValue { get; set; }
        public string TotalCoinsFreeFloat { get; set; }
        public string SortOrder { get; set; }
        public bool Sponsored { get; set; }
        public DateTime RecordDate { get; set; }
//        [JsonProperty(PropertyName = "Data")]
//        public SocialStats SocialStats { get; set; }
//
//        public Coin()
//        {
//            SocialStats = new SocialStats();
//        }
    }

    public class CoinData
    {
        public Dictionary<string,Coin> Data { get; set; }
    }
}