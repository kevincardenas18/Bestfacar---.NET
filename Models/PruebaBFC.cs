using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaBestfacar.Models
{
    public class PruebaBFC: DbContext
    {
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Caracteristicas> Caracteristicas { get; set; }
        public DbSet<Motor> Motor { get; set; }
        public DbSet<Transmision> Transmision { get; set; }
        public DbSet<Suspension> Suspension { get; set; }
        public DbSet<Frenos> Frenos { get; set; }
        public DbSet<Neumaticos> Neumaticos { get; set; }
        public DbSet<Capacidades> Capacidades { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Carrosel> Carrosel { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        public DbSet<Calificacion> Calificacion { get; set; }
    }
}