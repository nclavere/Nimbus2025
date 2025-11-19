using Newtonsoft.Json;
using Nimbus2025Transverse.Dtos;

namespace Nimbus2025Wpf.Services;

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

    public List<AirportDto> Airports { get; set; } = null!;
    public List<ItemDto> Companies { get; set; } = null!;
    public List<ItemDto> Cities { get; set; } = null!;

    public async Task LoadParameters()
    {
        Airports = await HttpClientService.Instance.GetAeroports();
        Companies = await HttpClientService.Instance.GetCompanies();
        Cities = await HttpClientService.Instance.GetCities();
    }


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

    public async Task<List<FlightDto>> GetFlights()
    {
        string route = $"Flights";
        var response = await Client.GetAsync(route);

        if (response.IsSuccessStatusCode)
        {
            string resultat = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<FlightDto>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    private async Task<List<ItemDto>> GetParameters(string parameter)
    {
        string route = $"Parameters/{parameter}";
        var response = await Client.GetAsync(route);

        if (response.IsSuccessStatusCode)
        {
            string resultat = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ItemDto>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public async Task<List<ItemDto>> GetCompanies()
    {
        return await GetParameters("Companies");
    }   
    public async Task<List<ItemDto>> GetCities()
    {
        return await GetParameters("Cities");
    }

    internal void SaveFlight(FlightDto flight)
    {
        if(flight.Id == 0)
        {
            Console.WriteLine("Création d'un vol -> appel POST");
        }
        else
        {
            Console.WriteLine("Modification d'un vol -> appel PUT");
        }
        
    }
}
