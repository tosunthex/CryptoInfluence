using System.Collections.Generic;
using System.Threading.Tasks;
using cointweety.Core.Model;

namespace cointweety.Core
{
    public interface ICoinTweet
    {
        void Add(CoinTweet coinTweet);
        Task<IEnumerable<CoinTweet>> GetAll();
    }
}