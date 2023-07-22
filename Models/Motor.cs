using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaBestfacar.Models
{
    public class Motor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MotorID { get; set; }
        public int VehiculoID { get; set; }
        public decimal Cilindraje { get; set; }
        public int Potencia { get; set; }
        public int Torque { get; set; }
        public string Combustible { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}