using System.Threading.Tasks;

namespace cointweety.Core
{
    public interface IJsonDeserialize
    {
        Task<string> DeserializeJsonFromUrl(string URL);
    }
}