using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nimbus2025Wpf.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        public UserControl ControlAffiche { get; set; } = null!;


        public ICommand CommandAeroports { get; set; } = null!;
        public ICommand CommandVols { get; set; } = null!;
        public ICommand CommandReservations { get; set; } = null!;


        public MainViewModel()
        {
            CommandAeroports = new RelayCommand(o => AfficherAeroports());
            CommandVols = new RelayCommand(o => AfficherVols());
            CommandReservations = new RelayCommand(o => AfficherReservations());
        }


        private void AfficherAeroports()
        {
            ControlAffiche = new Views.UcAeroports();
            NotifyPropertyChanged(nameof(ControlAffiche));
        }

        private void AfficherVols()
        {
            ControlAffiche = new Views.UcAeroports();
            NotifyPropertyChanged(nameof(ControlAffiche));
        }

        private void AfficherReservations()
        {
            ControlAffiche = new Views.UcAeroports();
            NotifyPropertyChanged(nameof(ControlAffiche));
        }

    }
}
