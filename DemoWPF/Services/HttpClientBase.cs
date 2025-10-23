using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Nimbus2025Transverse.Dtos;

namespace DemoWPF.Services
{
    abstract class HttpClientBase
    {
        private const string baseAddress = "https://localhost:7069/api/";
        private HttpClient client;
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
