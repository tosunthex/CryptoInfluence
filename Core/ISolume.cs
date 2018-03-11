using System.Collections.Generic;
using System.Threading.Tasks;
using cointweety.Core.Model;

namespace cointweety.Core
{
    public interface ISolume
    {
        Task<IEnumerable<SolumeDetail>> GetAll();
        Task Add(SolumeDetail solumeDetail);
        Task<SolumeDetail> GetLastestBySymbol(string symbol);
        Task<Dictionary<string, SolumeDetail>> DeserializeJson(string symbol);
    }
}