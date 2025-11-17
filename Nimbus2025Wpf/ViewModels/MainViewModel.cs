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

        private ICommand commandAeroports = null!;
		public ICommand CommandAeroports
		{
			get 
			{ 
				if(commandAeroports == null)
				{
					commandAeroports = new RelayCommand(
                        o =>
                        {
                            //corps de la méthode exécutée par la commande
                            ControlAffiche = new Views.UcAeroports();
							//instance de la vue model aeroports ...
                            NotifyPropertyChanged(nameof(ControlAffiche));
                        });
                }

				return commandAeroports; 
			}
		}

		

	}
}
