using System.Threading.Tasks;
using cointweety.Core.Model;

namespace cointweety.Core
{
    public interface ICoinSocialMediaAddress
    {
        Task<CoinSocialMediaAddress> GetBySymbol(string symbol);
        Task<CoinSocialMediaAddress> GetByTwitterScreenName(string screenName);
    }
}