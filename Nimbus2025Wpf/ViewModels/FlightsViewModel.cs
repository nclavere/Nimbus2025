using Nimbus2025Transverse.Dtos;
using Nimbus2025Wpf.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Nimbus2025Wpf.ViewModels;
internal class FlightsViewModel : ViewModelBase
{
    public FlightsViewModel()
    {
        CommandAjouter = new RelayCommand(o => AjouterUnVol());
        _ = LoadAeroportsAsync();
    }

    // Liste observable des vols 
    // chaque élément est un FlightViewModel qui permet d'ajouter des éléments d'affichage et de manipulation à l'entité dto brute
    public ObservableCollection<FlightViewModel> Flights { get; set; } = null!;
    public ICollectionView Observer { get; set; } = null!;
    
    //Le vol en cours de sélection
    public FlightViewModel? CurrentFlight {
        get => Observer?.CurrentItem == null ? null : (FlightViewModel?)Observer?.CurrentItem!;
    }
    public Visibility DetailVisibility { get => CurrentFlight == null ? Visibility.Collapsed : Visibility.Visible; }

    //Commande d'ajout d'un vol
    public ICommand CommandAjouter { get; set; } = null!;

    private async Task LoadAeroportsAsync()
    {
        //1. on récupère les données du modèle
        var flights = await HttpClientService.Instance.GetFlights();

        //2. on les place dans la liste observable
        Flights = new ObservableCollection<FlightViewModel>();
        flights.ForEach(a => Flights.Add(new FlightViewModel(a)));

        //3. on pose un observateur
        Observer = CollectionViewSource.GetDefaultView(Flights);

        Observer.SortDescriptions.Add(
            new SortDescription(nameof(FlightDto.Departure), ListSortDirection.Ascending)
        );

        //4. on veut être notifié du changement de sélection coté vue
        Observer.CurrentChanged += (sender, e) =>
        {            
            NotifyPropertyChanged(nameof(CurrentFlight));
            NotifyPropertyChanged(nameof(DetailVisibility));
        };        

        //5. on notifie la vue que la liste a changé
        NotifyPropertyChanged(nameof(Flights));

        //désélectionne par défaut
        Observer.MoveCurrentTo(null);
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
                    FlightViewModel aeroport = (FlightViewModel)obj;
                    return aeroport.Flight.AirportTo.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase)
                    || aeroport.Flight.AirportFrom.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase);
                };
            }
        }
    }

    private void AjouterUnVol()
    {
        //création d'un nouveau vol vide
        var vol = new FlightDto();

        //ajout à la fin de la liste observable
        var vm = new FlightViewModel(vol);
        Flights.Add(vm);

        //on se met sur le l'élément ajouté pour le montrer à l'utilisateur
        Observer.MoveCurrentTo(vm);
    }


}
