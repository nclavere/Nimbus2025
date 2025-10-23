using DemoWPF.Services;
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
        public UcAeroports()
        {
            InitializeComponent();
            _ = LoadAeroportsAsync();
        }

        private async Task LoadAeroportsAsync()
        {
            var lst = await HttpClientService.Instance.GetAeroports();
            lstb.ItemsSource = lst;
        }
    }
}
