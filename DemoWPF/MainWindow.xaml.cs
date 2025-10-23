using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoWPF;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

   

    private void Bienvenue_Click(object sender, RoutedEventArgs e)
    {
        var ctrl = new Views.UcBienvenue();
        MyContent.Content = ctrl;
    }

    private void Aeroports_Click(object sender, RoutedEventArgs e)
    {
        //MessageBox.Show("Aéroports à venir ...");

        //var msg = new Views.Message();
        //msg.Info.Text = "Bienvenue !";
        //msg.ShowDialog();

        var ctrl = new Views.UcAeroports();
        MyContent.Content = ctrl;
    }
}