using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaBestfacar.Models
{
    public class Transmision
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransmisionID { get; set; }
        public int VehiculoID { get; set; }
        public string Tipo { get; set; }
        public string Caja { get; set; }
        public string Traccion { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}