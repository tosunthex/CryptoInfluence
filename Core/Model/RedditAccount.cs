namespace cointweety.Core.Model
{
    public class RedditAccount
    {
        public string posts_per_hour { get; set; }
        public string comments_per_hour { get; set; }
        public string posts_per_day { get; set; }
        public double comments_per_day { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public int active_users { get; set; }
        public string community_creation { get; set; }
        public int subscribers { get; set; }
        public int Points { get; set; }
    }
}