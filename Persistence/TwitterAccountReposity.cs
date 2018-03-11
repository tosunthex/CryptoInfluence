using System.Collections.Generic;
using System.Threading.Tasks;
using cointweety.Core;
using cointweety.Core.Model;
using cointweety.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace cointweety.Persistence
{
    public class TwitterAccountReposity:ITwitterAccount
    {
        private readonly IJsonDeserialize _jsonDeserialize;
        private readonly RestApiOptions _restApiOptions;
        
        public TwitterAccountReposity(IOptions<RestApiOptions> restApiOptions,IJsonDeserialize jsonDeserialize)
        {
            _jsonDeserialize = jsonDeserialize;
            _restApiOptions = restApiOptions.Value;
        }
        
        public Task Add(TwitterAccount twitterAccount)
        {
            throw new System.NotImplementedException();
        }

        public Task<TwitterAccount> GetBySymbol(string Symbol)
        {
            throw new System.NotImplementedException();
        }


    }
}