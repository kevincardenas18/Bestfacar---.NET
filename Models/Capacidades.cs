using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaBestfacar.Models
{
    public class Capacidades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CapacidadesID { get; set; }
        public int VehiculoID { get; set; }
        public int NumeroPuertas { get; set; }
        public int NumeroPasajeros { get; set; }
        public decimal Longitud { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
        public decimal DistanciaEjes { get; set; }
        public decimal AlturaSuelo { get; set; }
        public decimal VolumenMaletero { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}