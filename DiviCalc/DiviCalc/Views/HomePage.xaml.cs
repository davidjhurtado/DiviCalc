using System;
using Xamarin.Forms;
using DiviCalc.ViewModel;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace DiviCalc.Views {
    public partial class HomePage : ContentPage {
        //private decimal cambio = (decimal)2916071.30;
        private readonly HomeViewModel viewModel;
        public HomePage() {
            InitializeComponent();
            BindingContext = viewModel = new HomeViewModel();

            //entryCambio.Text = cambio.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e) {
            lblResulBs.Text = (Convert.ToDecimal(entryDivisas.Text) * Convert.ToDecimal(lblCambio.Text) * 1).ToString();
        }

        private void  btnCopiar_Clicked(object sender, EventArgs e) {
            Task.Run(async () => await Clipboard.SetTextAsync(lblResulBs.Text));
        }
    }
}
