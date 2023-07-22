using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaBestfacar.Models
{
    public class Neumaticos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NeumaticosID { get; set; }
        public int VehiculoID { get; set; }
        public string Descripcion { get; set; }
        public string TipoAros { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}