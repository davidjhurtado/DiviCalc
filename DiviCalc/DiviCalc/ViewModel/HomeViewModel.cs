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
            await Task.Delay(1000);
            var _cambios = await CambioService.GetCambiosListAsync();
            var listaordenada = _cambios.OrderByDescending(p => p.Fecha);
            TasaDeCambio = _cambios.OrderByDescending(p => p.Fecha).FirstOrDefault().TasaDeCambio.ToString();
            await Task.Delay(1000);
            IsBusy = false;
        }

    }
}
