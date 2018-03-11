namespace cointweety.Core.Model
{
    public class TwitterAccount
    {
        public string following { get; set; }
        public string account_creation { get; set; }
        public string name { get; set; }
        public int lists { get; set; }
        public int statuses { get; set; }
        public string favourites { get; set; }
        public int followers { get; set; }
        public string link { get; set; }
        public int Points { get; set; }
    }

    public class Data
    {
        public TwitterAccount TwitterAccount { get; set; }
    }
}