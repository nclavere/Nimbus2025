using Nimbus2025Transverse.Dtos;
using Nimbus2025Wpf.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Nimbus2025Wpf.ViewModels;
internal class AeroportsViewModel : ViewModelBase
{

    public ObservableCollection<AirportDto> Aeroports { get; set; } = null!;
    public ICollectionView Observer { get; set; }

    public string SelectedAeroportDetails { 
        get
        {
            return Observer?.CurrentItem != null ? 
                ((AirportDto)Observer.CurrentItem).Name 
                : "Aucun aéroport sélectionné";
        }
    }

    public AeroportsViewModel()
    {
        _ = LoadAeroportsAsync();
    }

    private async Task LoadAeroportsAsync()
    {
        //1. on récupère les données du modèle
        var aeroports = await HttpClientService.Instance.GetAeroports();

        //2. on les place dans la liste observable
        Aeroports = new ObservableCollection<AirportDto>();
        aeroports.ForEach(a => Aeroports.Add(a));

        //3. on pose un observateur
        Observer = CollectionViewSource.GetDefaultView(Aeroports);

        Observer.SortDescriptions.Add(
            new SortDescription(nameof(AirportDto.Code), ListSortDirection.Descending)
        );

        //4. on veut être notifié du changement de sélection coté vue
        Observer.CurrentChanged += (sender, e) =>
        {
            NotifyPropertyChanged(nameof(SelectedAeroportDetails));
        };        

        //5. on notifie la vue que la liste a changé
        NotifyPropertyChanged(nameof(Aeroports));
        Observer.MoveCurrentToLast();
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
                    AirportDto aeroport = (AirportDto)obj;
                    return aeroport.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase);
                };
            }
        }
    }


}
