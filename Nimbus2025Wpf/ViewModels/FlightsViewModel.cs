using Nimbus2025Transverse.Dtos;
using Nimbus2025Wpf.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Nimbus2025Wpf.ViewModels;
internal class FlightsViewModel : ViewModelBase
{

    public ObservableCollection<FlightDto> Flights { get; set; } = null!;
    public ICollectionView Observer { get; set; } = null!;

    public string SelectedFlightDetails { 
        get
        {
            return Observer?.CurrentItem != null ? 
                ((AirportDto)Observer.CurrentItem).Name 
                : "Aucun vol sélectionné";
        }
    }

    public FlightsViewModel()
    {
        _ = LoadAeroportsAsync();
    }

    private async Task LoadAeroportsAsync()
    {
        //1. on récupère les données du modèle
        var flights = await HttpClientService.Instance.GetFlights();

        //2. on les place dans la liste observable
        Flights = new ObservableCollection<FlightDto>(flights);
        //Flights.ForEach(a => Flights.Add(a));

        //3. on pose un observateur
        Observer = CollectionViewSource.GetDefaultView(Flights);

        Observer.SortDescriptions.Add(
            new SortDescription(nameof(FlightDto.Departure), ListSortDirection.Ascending)
        );

        //4. on veut être notifié du changement de sélection coté vue
        Observer.CurrentChanged += (sender, e) =>
        {
            NotifyPropertyChanged(nameof(SelectedFlightDetails));
        };        

        //5. on notifie la vue que la liste a changé
        NotifyPropertyChanged(nameof(Flights));
    }

    public string Filtre
    {
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Observer.Filter = null;
            }
            else
            {
                Observer.Filter = obj =>
                {
                    FlightDto aeroport = (FlightDto)obj;
                    return aeroport.AirportTo.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase)
                    || aeroport.AirportFrom.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase);
                };
            }
        }
    }


}
