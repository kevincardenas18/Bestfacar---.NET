using PruebaBestfacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaBestfacar.Controllers
{
    public class CompararController : Controller
    {

        private readonly PruebaBFC _contexto;

        public CompararController(PruebaBFC contexto)
        {
            _contexto = contexto;
        }
        /*
        public ActionResult CompararVehiculos(int vehiculo1, int vehiculo2)
        {
            var vehiculo1Data = _contexto.Vehiculo.Include(v => v.Calificacion)
                                                   .Include(v => v.Motor)
                                                   .Include(v => v.Neumaticos)
                                                   .Include(v => v.Caracteristicas)
                                                   .Include(v => v.Suspension)
                                                   .FirstOrDefault(v => v.VehiculoID == vehiculo1);

            var vehiculo2Data = _contexto.Vehiculo.Include(v => v.Calificacion)
                                                   .Include(v => v.Motor)
                                                   .Include(v => v.Neumaticos)
                                                   .Include(v => v.Caracteristicas)
                                                   .Include(v => v.Suspension)
                                                   .FirstOrDefault(v => v.VehiculoID == vehiculo2);

            if (vehiculo1Data == null || vehiculo2Data == null)
            {
                return RedirectToAction("Index"); // Redirige a la página de inicio o a una página de error si no se encuentran los vehículos
            }

            var comparativa = new List<ComparativaCampo>();

            comparativa.Add(new ComparativaCampo { Nombre = "Marca", ValorVehiculo1 = vehiculo1Data.Marca, ValorVehiculo2 = vehiculo2Data.Marca });
            comparativa.Add(new ComparativaCampo { Nombre = "Modelo", ValorVehiculo1 = vehiculo1Data.Modelo, ValorVehiculo2 = vehiculo2Data.Modelo });
            comparativa.Add(new ComparativaCampo { Nombre = "Calificación", ValorVehiculo1 = vehiculo1Data.Calificacion.Valor.ToString(), ValorVehiculo2 = vehiculo2Data.Calificacion.Valor.ToString() });
            // Agrega más campos según tus necesidades

            ViewBag.Comparativa = comparativa;

            return View();
        }*/
    }

}