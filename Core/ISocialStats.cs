using System.Threading.Tasks;
using cointweety.Core.Model;

namespace cointweety.Core
{
    public interface ISocialStats
    {
        Task<SocialStats> GetById(string Id);
    }
}