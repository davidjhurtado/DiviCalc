using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DiviCalc.ViewModel;

namespace DiviCalc.Views {
    public partial class HomePage : ContentPage {
        private decimal cambio = (decimal)2916071.30;
        private readonly HomeViewModel viewModel;
        public HomePage() {
            InitializeComponent();
            BindingContext = viewModel = new HomeViewModel();
            entryCambio.Text = cambio.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e) {
            lblResulBs.Text = (Convert.ToDecimal(entryDivisas.Text) * Convert.ToDecimal(entryCambio.Text)).ToString();
        }
    }
}
