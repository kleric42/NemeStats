using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace NemeStatsApiClient
{
    public class NemeStatsClient
    {
        public const string BASE_URL_API_VERSION_2 = "https://nerdscorekeeper.azurewebsite.net/api/v2";
        private IRestClient _resetClient;

        public NemeStatsClient(string nemeStatsBaseApiUrl = BASE_URL_API_VERSION_2)
        {
            _resetClient = new RestClient(nemeStatsBaseApiUrl);
        }


    }
}
