using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace DiviCalc.Models {
    [Table("Cambios")]
    public  class Cambio {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public decimal TasaDeCambio { get; set; }
        public DateTime Fecha { get; set; }

    }
}
