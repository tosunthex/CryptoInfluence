using System.Collections.Generic;
using System.Threading.Tasks;
using cointweety.Core.Model;

namespace cointweety.Core
{
    public interface ICoinMarketCap
    {
        Task<IEnumerable<CoinMarketCap>> GetAllCoinMarketCap();
//        Task<CoinMarketCap> GetCoinMarketCap();
        Task Add(CoinMarketCap coinMarketCap);
//        Task<bool> RemoveCoinMarketCap();
//        Task<bool> UpdateCoinMarketCap();
        Task<CoinMarketCap> GetLastestBySymbol(string symbol);
        Task<IEnumerable<CoinMarketCap>> DeserializeJson(string limit);
    }
}