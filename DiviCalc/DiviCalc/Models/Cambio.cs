using System;
using System.Collections.Generic;
using System.Text;

namespace DiviCalc.Models {
    public class Cambio {
        public decimal TasaDeCambio { get; set; }
        public DateTime Fecha { get; set; }

        public Cambio(decimal tasadeCambio, DateTime fecha) {
            TasaDeCambio = tasadeCambio;
            Fecha = fecha;
        }
    }
}
