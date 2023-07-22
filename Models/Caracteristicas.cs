using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaBestfacar.Models
{
    public class Caracteristicas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int caracteristicasID { get; set; }
        public int VehiculoID { get; set; }
        public string descripcion { get; set; }
        public string direccion { get; set; }
        [JsonIgnore]
        public virtual Vehiculo Vehiculo { get; set; }
    }
}