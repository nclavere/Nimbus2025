using Nimbus2025Transverse.Dtos;
using Nimbus2025Wpf.Services;
using System.Collections.ObjectModel;

namespace Nimbus2025Wpf.ViewModels;
internal class AeroportsViewModel : ViewModelBase
{

    public ObservableCollection<AirportDto> Aeroports { get; set; } = null!;

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

        //4. on veut être notifié du changement de sélection coté vue

        //5. on notifie la vue que la liste a changé
        NotifyPropertyChanged(nameof(Aeroports));
    }




}
