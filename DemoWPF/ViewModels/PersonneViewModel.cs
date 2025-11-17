using DemoWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemoWPF.ViewModels
{
    class PersonneViewModel : ViewModelBase
    {
        public Personne Personne { get; set; }

        public PersonneViewModel(Personne personne)
        {
            Personne = personne;
        }


        public string TexteBienvenue { get; set; } = null!;

        public string Nom
        {
            get { return Personne.Nom; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    (Personne.Nom?.Length > 2 && value.Length <= 2)) return;

                Personne.Nom = value;
                TexteBienvenue = $"Bienvenue {Personne.Nom} !";
                NotifyPropertyChanged(nameof(TexteBienvenue));
            }
        }

        private bool afficherTextes = true;
        public bool AfficherTextes
        {
            get { return afficherTextes; }
            set { 
                afficherTextes = value;
                NotifyPropertyChanged();
            }
        }

    }
}
