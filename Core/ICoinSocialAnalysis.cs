using System.Collections.Generic;
using System.Threading.Tasks;
using cointweety.Core.Model;

namespace cointweety.Core
{
    public interface ICoinSocialAnalysis
    {
        Task Add(CoinSocialAnalysis coinSocialAnalysis);
        Task<IEnumerable<CoinSocialAnalysis>> GetAll();
    }
}