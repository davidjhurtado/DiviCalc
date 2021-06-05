using DiviCalc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DiviCalc.ViewModel {
    public class HomeViewModel:BaseViewModel {
        private string tasaDeCambio = "0";
        public Command ObtenerCambio  { get; }

        
        public string TasaDeCambio {
            get { return tasaDeCambio; }
            set {
                SetProperty(ref tasaDeCambio ,value);
                
            }
        }
        public HomeViewModel() {
            Title = "DiviCal - Calculadora de divisas";
            ObtenerCambio = new Command(async() => await ObtenerCambioAsync());
            Task.Run(async () => await ObtenerCambioAsync());
        }

        private async Task ObtenerCambioAsync() {
            IsBusy = true;
            IEnumerable<Models.Cambio> _cambios = await CambioService.GetCambiosListAsync();
            TasaDeCambio = string.Format("{0:n}", _cambios.OrderByDescending(p => p.Fecha).FirstOrDefault().TasaDeCambio);
            IsBusy = false;
        }

    }
}
