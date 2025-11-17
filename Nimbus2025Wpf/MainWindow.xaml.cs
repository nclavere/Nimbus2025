using Nimbus2025Wpf.ViewModels;
using System.Windows;

namespace Nimbus2025Wpf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        //ne pas oublier de définir le DataContext avec l'instance de notre 1ère VM
        this.DataContext = new MainViewModel();

    }
}