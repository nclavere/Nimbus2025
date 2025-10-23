using DemoWPF.Services;
using Nimbus2025Transverse.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour UcAeroports.xaml
    /// </summary>
    public partial class UcAeroports : UserControl
    {
        private List<AirportDto> _aeroports = new List<AirportDto>();

        public UcAeroports()
        {
            InitializeComponent();
            _ = LoadAeroportsAsync();
        }

        private async Task LoadAeroportsAsync()
        {
            _aeroports = await HttpClientService.Instance.GetAeroports();
            lstb.ItemsSource = _aeroports;
        }

        private void lstb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (AirportDto)lstb.SelectedItem;
            MessageBox.Show($"Vous avez sélectionné l'aéroport : {item.Name} ({item.Code})", "Aéroport sélectionné", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void filtre_KeyDown(object sender, KeyEventArgs e)
        {
            lstb.ItemsSource = _aeroports.Where(a => a.Name.Contains(filtre.Text, StringComparison.InvariantCultureIgnoreCase) ).ToList();
        }
    }
}
