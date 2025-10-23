using Newtonsoft.Json;
using Nimbus2025Transverse.Dtos;
using System.Net.Http;

namespace DemoWPF.Services
{
    class HttpClientService: HttpClientBase
    {
        #region Singleton

        //constructeur private => singleton (on ne peut plus instancier la classe de l'extérieur)
        private HttpClientService() { }

        //Singleton
        private static HttpClientService? instance;
        public static HttpClientService Instance {
            get
            {
                if(instance == null)
                {
                    instance = new HttpClientService();
                }   
                return instance;
            }
        }
        #endregion


        public async Task<List<AirportDto>> GetAeroports()
        {
            string route = $"Airports";
            var response = await Client.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AirportDto>>(resultat)
                    ?? throw new FormatException($"Erreur Http : {route}");
            }
            throw new Exception(response.ReasonPhrase);
        }


    }
}
