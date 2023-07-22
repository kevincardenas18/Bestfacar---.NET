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
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehiculoID { get; set; }

        //[Required(ErrorMessage = "*Campo Requerido"), Display(Name = "Marca del Vehiculo Ejm: BMW, Audi, Chevrolet")]

        public string Marca { get; set; }
        //[Required(ErrorMessage = "*Campo Requerido"), Display(Name = "Ingrese el Modelo del Vehiculo")]

        public string Modelo { get; set; }
        //[Required(ErrorMessage = "*Campo Requerido"), Display(Name = "Version del Vehiculo")]

        public string Version { get; set; }
        //[Required(ErrorMessage = "*Campo Requerido"), Display(Name = "Año del Vehiculo")]
        public int Anio { get; set; }
        public string Categoria { get; set; }
        //[Required(ErrorMessage = "*Campo Requerido"), Display(Name = "Nombre de Imagen")]
        public string NombreImagen { get; set; }
        public string UrlImage { get; set; }

        [Display(Name = "Imagen del Vehiculo"), DataType(DataType.Upload)]

        [JsonIgnore]
        public byte[] Imagen { get; set; }

        [JsonIgnore]
        public virtual ICollection<Caracteristicas> Caracteristicas { get; set; }
        [JsonIgnore]
        public virtual ICollection<Transmision> Transmision { get; set; }
        [JsonIgnore]
        public virtual ICollection<Suspension> Suspension { get; set; }
        [JsonIgnore]
        public virtual ICollection<Capacidades> Capacidades { get; set; }
        [JsonIgnore]
        public virtual ICollection<Neumaticos> Neumaticos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Frenos> Frenos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Motor> Motor { get; set; }
        [JsonIgnore]
        public virtual ICollection<Calificacion> Calificaciones { get; set; }

    }
}