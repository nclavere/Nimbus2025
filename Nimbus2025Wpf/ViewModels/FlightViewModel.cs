using Nimbus2025Transverse.Dtos;
using Nimbus2025Wpf.Services;
using System.Windows.Input;

namespace Nimbus2025Wpf.ViewModels;
internal class FlightViewModel : ViewModelBase
{
    public FlightDto Flight { get; set; }
    public ICommand CommandEnregistrer { get; set; } = null!;

    public FlightViewModel(FlightDto flight)
    {
        Flight = flight;
        CommandEnregistrer = new RelayCommand(o => Enregistrer());
        _ = LoadParameters();
    }

    public List<AirportDto> Airports { get; set; } = null!;
    public List<ItemDto> Companies { get; set; } = null!;
    public List<ItemDto> Cities { get; set; } = null!;


    public ItemDto? Company
    {
        get { return Companies?.FirstOrDefault(c => c.Name == Flight.CompanyName); }
        set { 
            if(value != null)
            {
                Flight.CompanyName = value.Name;
                NotifyPropertyChanged(nameof(Company));
            }
        }
    }

    public AirportDto? AirportFrom
    {
        get { return Airports?.FirstOrDefault(c => c.Name == Flight.AirportFrom.Name); }
        set
        {
            if (value != null)
            {
                Flight.AirportFrom = value;
                NotifyPropertyChanged(nameof(AirportFrom));
            }
        }
    }

    public AirportDto? AirportTo
    {
        get { return Airports?.FirstOrDefault(c => c.Name == Flight.AirportTo.Name); }
        set
        {
            if (value != null)
            {
                Flight.AirportTo = value;
                NotifyPropertyChanged(nameof(AirportTo));
            }
        }
    }


    public async Task LoadParameters()
    {
        Airports = await HttpClientService.Instance.GetAeroports();
        Companies = await HttpClientService.Instance.GetCompanies();        
        Cities = await HttpClientService.Instance.GetCities();
        NotifyPropertyChanged(nameof(Companies));
        NotifyPropertyChanged(nameof(Airports));
        NotifyPropertyChanged(nameof(Cities));
        NotifyPropertyChanged(nameof(Company));
        NotifyPropertyChanged(nameof(AirportFrom));
        NotifyPropertyChanged(nameof(AirportTo));
    }


    public void Enregistrer()
    {
         HttpClientService.Instance.SaveFlight(Flight);
    }



}
