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
        private ObservableCollection<Cambio> Cambios { get; set; }
        //public ObservableCollection<Cambio> Cambios {
        //    get { return cambios; }
        //    set { SetProperty<ObservableCollection<Cambio>>(ref cambios, value); }
        //}
        public Command RefreshCommand { get; }
        public Command BorrarCommand { get; private set; }
        public Command AgregarCommand { get; private set; }

        public CambioViewModel() {
            Title = "DiviCal - Cambios";
            Cambios = new ObservableCollection<Cambio>();
            RefreshCommand = new Command(async ()=> await RecargarAsync()) ;
            BorrarCommand = new Command(async () => await BorrarAsync(MiCambio));
            AgregarCommand = new Command(async () => await AgregarAsync(MiCambio));

            _ = Task.Run(async () => await RecargarAsync());
            MiCambio = Cambios.Count > 0
                ? Cambios.OrderByDescending(c => c.Fecha).FirstOrDefault()
                : new Cambio {
                    Fecha = DateTime.Today,
                    TasaDeCambio = (decimal)3073619.30
                };

        }

        private Cambio miCambio;

        public Cambio MiCambio {
            get { return miCambio; }
            set { SetProperty(ref  miCambio , value); }
        }


        private async Task AgregarAsync(Cambio cambio) {
            cambio.Fecha = DateTime.Now;
            await CambioService.AddCambioAsync(cambio.TasaDeCambio, cambio.Fecha);
            await RecargarAsync();
        }
        private async Task  BorrarAsync(Cambio cambio) {
            await CambioService.RemoveCambioAsync(cambio.Id);
            await RecargarAsync();
        }
        private async Task RecargarAsync() 
        {
            IsBusy = true;
            await Task.Delay(1000);
            Cambios.Clear();
            await Task.Delay(1000);
            var _cambios = await CambioService.GetCambiosListAsync();
            foreach (Cambio cambio in _cambios) {
                Cambios.Add(cambio);
            }
            IsBusy = false;
        }
    }
}
