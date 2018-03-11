using System.Collections.Generic;
using System.Threading.Tasks;
using cointweety.Core.Model;

namespace cointweety.Core
{
    public interface ICoin
    {
        void Add(Coin coin);
        Task<CoinData> DeseriliazeJson();
        Task<IEnumerable<Coin>> GetAll();
        Task<Coin> GetBySymbol(string symbol);
    }
}