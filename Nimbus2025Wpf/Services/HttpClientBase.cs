using System.Net.Http;

namespace Nimbus2025Wpf.Services
{
    abstract class HttpClientBase
    {
        private const string baseAddress = "https://localhost:7069/api/";
        private HttpClient client = null!;
        protected HttpClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri(baseAddress);
                }
                return client;
            }
        }
    }
}
