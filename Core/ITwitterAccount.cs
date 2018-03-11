using System.Collections.Generic;
using System.Threading.Tasks;
using cointweety.Core.Model;

namespace cointweety.Core
{
    public interface ITwitterAccount
    {
        Task Add(TwitterAccount twitterAccount);
        Task<TwitterAccount> GetBySymbol(string Symbol);
        
    }
}