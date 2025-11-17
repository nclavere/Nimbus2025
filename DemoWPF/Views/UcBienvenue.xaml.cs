using System.Windows;
using System.Windows.Controls;

namespace DemoWPF.Views;

public partial class UcBienvenue : UserControl
{
    public UcBienvenue()
    {
        InitializeComponent();

        var person = new Model.Personne();
        this.DataContext = new ViewModels.PersonneViewModel(person);
    }

}
