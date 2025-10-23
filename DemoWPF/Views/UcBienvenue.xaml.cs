using System.Windows;
using System.Windows.Controls;

namespace DemoWPF.Views;

public partial class UcBienvenue : UserControl
{
    public UcBienvenue()
    {
        InitializeComponent();

        var person = new Model.Personne();
        this.DataContext = person;
    }

    private void Ok_Click(object sender, RoutedEventArgs e)
    {
        var person = (Model.Personne)this.DataContext;

        tbBienvenue.Text = $"Bienvenue, {person.Nom}!"
;
    }
}
