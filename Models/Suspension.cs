using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaBestfacar.Models
{
    public class Suspension
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SuspensionID { get; set; }
        public int VehiculoID { get; set; }
        public string Delantera { get; set; }
        public string Trasera { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}