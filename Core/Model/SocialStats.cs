using Newtonsoft.Json;

namespace cointweety.Core.Model
{
    
    public class SocialStats
    {
        public TwitterAccount Twitter { get; set; }
        public FacebookAccount Facebook { get; set; }
        public RedditAccount Reddit { get; set; }
    }

    public class SocialStatsData
    {
        public SocialStats Data { get; set; }
    }
}