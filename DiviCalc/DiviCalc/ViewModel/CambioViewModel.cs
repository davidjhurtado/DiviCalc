using DiviCalc.Models;
using DiviCalc.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DiviCalc.ViewModel {
    public class CambioViewModel : BaseViewModel {
        public ObservableCollection<Cambio> Cambios { get; set; }        
        public Command RefreshCommand { get; }
        public Command BorrarCommand { get;  private set; }
        public Command AgregarCommand { get; private set; }
        private Cambio miCambio;
        public Cambio MiCambio {
            get { return miCambio; }
            set {
                SetProperty(ref miCambio, value);
            }
        }

        public CambioViewModel() {
            Title = "DiviCal - Cambios";
            Cambios = new ObservableCollection<Cambio>();
            RefreshCommand = new Command(async ()=> await RecargarAsync()) ;
            BorrarCommand = new Command(async () => await BorrarAsync(MiCambio.Id));
            AgregarCommand = new Command<string>(async (string tasaDeCambio) => await AgregarAsync(tasaDeCambio));

        _ = Task.Run(async () => await RecargarAsync());
            if (Cambios.Count == 0) {
                MiCambio = new Cambio {
                    Fecha = new DateTime(2021,05,21,13,00,00),
                    TasaDeCambio = (decimal)3115347.30
                    };
                _ = Task.Run(async () => await AgregarAsync(MiCambio.TasaDeCambio.ToString()));
                _ = Task.Run(async () => await RecargarAsync());
            }
            
            MiCambio = Cambios.OrderByDescending(c => c.Fecha).FirstOrDefault();
        }

        private async Task AgregarAsync(string tasaDeCambio) {
            var cambio = new Cambio {
                Fecha = DateTime.Now,
                TasaDeCambio = decimal.Parse(tasaDeCambio)
            };
            await CambioService.AddCambioAsync(cambio.TasaDeCambio, cambio.Fecha);
            await RecargarAsync();
        }
        
        private async Task  BorrarAsync(int Id) {
            await CambioService.RemoveCambioAsync(Id);
            await RecargarAsync();
        }
        private async Task RecargarAsync() 
        {
            IsBusy = true;
            await Task.Delay(1000);
            Cambios.Clear();
            await Task.Delay(1000);
            var _cambios = await CambioService.GetCambiosListAsync();
            foreach (Cambio cambio in _cambios.OrderByDescending(c => c.Fecha)) {
                Cambios.Add(cambio);
            }
            IsBusy = false;
        }
    }
}
