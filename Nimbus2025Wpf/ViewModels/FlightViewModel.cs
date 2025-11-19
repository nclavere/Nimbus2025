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
    }

    //Pour fournir les listes déroulantes
    public List<AirportDto> Airports { get => HttpClientService.Instance.Airports; }
    public List<ItemDto> Companies { get => HttpClientService.Instance.Companies; }
    public List<ItemDto> Cities { get => HttpClientService.Instance.Cities; }

    //Pour fournir les éléments sélectionnés des listes déroulantes
    public ItemDto? Company
    {
        get { return HttpClientService.Instance.Companies?.FirstOrDefault(c => c.Name == Flight.CompanyName); }
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
        get { return HttpClientService.Instance.Airports?.FirstOrDefault(c => c.Name == Flight.AirportFrom?.Name); }
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
        get { return HttpClientService.Instance.Airports?.FirstOrDefault(c => c.Name == Flight.AirportTo?.Name); }
        set
        {
            if (value != null)
            {
                Flight.AirportTo = value;
                NotifyPropertyChanged(nameof(AirportTo));
            }
        }
    }


    public void Enregistrer()
    {
         HttpClientService.Instance.SaveFlight(Flight);
    }



}
