using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaBestfacar.Models
{
    public class Frenos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FrenosID { get; set; }
        public int VehiculoID { get; set; }
        public string FrenosDelanteros { get; set; }
        public string FrenosTraseros { get; set; }
        public string FrenosEstacionamiento { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}