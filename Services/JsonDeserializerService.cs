using System.Net.Http;
using System.Threading.Tasks;
using cointweety.Core;

namespace cointweety.Services
{
    public class JsonDeserializerService:IJsonDeserialize
    {
        public async Task<string> DeserializeJsonFromUrl(string url)
        {
            var restClient = new HttpClient();

            var response =  await restClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;
               
            return await response.Content.ReadAsStringAsync();
        } 
        
    }
}