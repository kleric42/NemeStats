using System.Configuration.Abstractions;
using System.Linq;
using NemeStatsApiClient;
using NUnit.Framework;

namespace NemeStatsApiClientTests.UsersClientTests
{
    [TestFixture]
    public class RegisterNewUserTests
    {
        private NemeStatsClient _apiClient;

        [SetUp]
        public void SetUp()
        {
            _apiClient = new NemeStatsClient(ConfigurationManager.Instance.AppSettings.Get("apiBaseUrl"));
        }
    }
}
