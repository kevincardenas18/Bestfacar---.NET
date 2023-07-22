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
    public class RolUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RolID { get; set; }
        public string Descripcion { get; set; }
        [JsonIgnore]
        public virtual ICollection<Usuarios> Usuarios { get; set; }

        
    }
}