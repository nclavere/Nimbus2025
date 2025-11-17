using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nimbus2025Wpf.ViewModels
{
    class MainViewModel : ViewModelBase
    {

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
                            //corpd de la méthode exécutée par la commande


                        });
                }

				return commandAeroports; 
			}
		}

		

	}
}
