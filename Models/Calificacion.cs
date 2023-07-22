using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PruebaBestfacar.Models
{
    public class Calificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int calificacionID { get; set; }
        public int VehiculoID { get; set; }
        public float proteccionFrontal { get; set; }
        public float proteccionLateral { get; set; }
        public float proteccionInfantil { get; set; }
        public float sistemasSeguridad { get; set; }
        public float proteccionPeaton { get; set; }
        public float equipamiento { get; set; }
        [JsonIgnore]
        public virtual Vehiculo Vehiculo { get; set; }
    }
}