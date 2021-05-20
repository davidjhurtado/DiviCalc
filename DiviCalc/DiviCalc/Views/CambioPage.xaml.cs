using DiviCalc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiviCalc.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CambioPage : ContentPage {
        private readonly CambioViewModel cambioViewModel;
        public CambioPage() {
            InitializeComponent();
            BindingContext = cambioViewModel = new CambioViewModel();
        }
    }
}