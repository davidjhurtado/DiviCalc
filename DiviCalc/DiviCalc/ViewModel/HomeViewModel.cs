using System;
using System.Collections.Generic;
using System.Text;

namespace DiviCalc.ViewModel {
    public class HomeViewModel:BaseViewModel {
        private decimal tasaDeCambio = 0;
        

        public decimal TasaDeCambio {
            get { return tasaDeCambio; }
            set {
                if (tasaDeCambio == value) {
                    return;
                }

                tasaDeCambio = value;
            }
        }

        public string Titulo {
            get { return "DiviCal - Calculadora de divisas"; }
            
        }



    }
}
