using PruebaBestfacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PruebaBestfacar.Permisos;



namespace PruebaBestfacar.Controllers
{
    [Authorize]
    //[PermisosRolAttribute(Models.Rol.Usuario)]
    public class HomeController : Controller
    {
        private PruebaBFC db = new PruebaBFC();
        public ActionResult Index()
        {
            return View(db.Carrosel.ToList());
        }

        public ActionResult NoAutorizado()
        {
            ViewBag.Message = "NO TIENES PERMISOS DE ADMINISTRADOR";
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session["Usuarios"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Access");
            // Borrar el caché
            var cacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                var cacheItemKey = cacheEnum.Key.ToString();
                HttpRuntime.Cache.Remove(cacheItemKey);
            }

        }

        public ActionResult VehiculosPresentacion()
        {
            return View(db.Vehiculo.ToList());
        }

        public ActionResult VisualizarVehiculos()
        {
            return View(db.Vehiculo.ToList());
        }

        private string GetImagenUrl(byte[] imagenBytes)
        {
            if (imagenBytes != null && imagenBytes.Length > 0)
            {
                var base64String = Convert.ToBase64String(imagenBytes);
                return string.Format("data:image/png;base64,{0}", base64String);
            }
            return null;
        }

        [HttpPost]
        public ActionResult CompararVehiculos(int vehiculo1, int vehiculo2)
        {
            var vehiculo1Data = db.Vehiculo.FirstOrDefault(v => v.VehiculoID == vehiculo1);
            var vehiculo2Data = db.Vehiculo.FirstOrDefault(v => v.VehiculoID == vehiculo2);
            var calificacionVehiculo1 = db.Calificacion.FirstOrDefault(c => c.VehiculoID == vehiculo1);
            var calificacionVehiculo2 = db.Calificacion.FirstOrDefault(c => c.VehiculoID == vehiculo2);

            float suma1 = calificacionVehiculo1.proteccionFrontal + calificacionVehiculo1.proteccionLateral+calificacionVehiculo1.proteccionPeaton+calificacionVehiculo1.sistemasSeguridad+calificacionVehiculo1.proteccionInfantil;
            float suma2 = calificacionVehiculo2.proteccionFrontal + calificacionVehiculo2.proteccionLateral + calificacionVehiculo2.proteccionPeaton + calificacionVehiculo2.sistemasSeguridad+ calificacionVehiculo2.proteccionInfantil;

            float Promedio1 = suma1/5;
            float Promedio2 = suma2/5;

            var comparativa = new List<ComparativaCampo>();

            comparativa.Add(new ComparativaCampo("Imagen", "", "", GetImagenUrl(vehiculo1Data.Imagen), GetImagenUrl(vehiculo2Data.Imagen)));
            comparativa.Add(new ComparativaCampo("Marca", vehiculo1Data.Marca, vehiculo2Data.Marca, "", ""));
            comparativa.Add(new ComparativaCampo("Modelo", vehiculo1Data.Modelo, vehiculo2Data.Modelo, "", ""));
            comparativa.Add(new ComparativaCampo("Versión", vehiculo1Data.Version, vehiculo2Data.Version, "", ""));
            comparativa.Add(new ComparativaCampo("Año", vehiculo1Data.Anio.ToString(), vehiculo2Data.Anio.ToString(), "", ""));
            comparativa.Add(new ComparativaCampo("Categoría", vehiculo1Data.Categoria, vehiculo2Data.Categoria, "", ""));
            comparativa.Add(new ComparativaCampo("Calificacion Equipamiento", calificacionVehiculo1.equipamiento.ToString(), calificacionVehiculo2.equipamiento.ToString(), "", ""));
            comparativa.Add(new ComparativaCampo("Calificacion en Segurida", Promedio1.ToString(), Promedio2.ToString(), "", ""));

            ViewBag.Comparativa = comparativa;

            if (Promedio1 > Promedio2)
            {
                ViewBag.MensajeMayorSeguridad = "El vehículo 1 tiene mayor Proteccion al momento de un accidente";
            }
            else if (Promedio2 > Promedio1)
            {
                ViewBag.MensajeMayorSeguridad = "El vehículo 2 tiene mayor Proteccion al momento de un accidente";
            }

            if(calificacionVehiculo1.equipamiento>calificacionVehiculo2.equipamiento)
            {
                ViewBag.MensajeEquipamiento = "El vehículo 1 tiene un mejor equipamiento de materiales de confort";

            }
            else if (calificacionVehiculo2.equipamiento > calificacionVehiculo1.equipamiento)
            {
                ViewBag.MensajeEquipamiento = "El vehículo 2 tiene un mejor equipamiento de materiales de confort";

            }

            return View("VehiculosPresentacion");
        }

        [HttpGet]
        public ActionResult Reporte()
        {
            var categorias = db.Vehiculo.Select(v => v.Categoria).Distinct().ToList();
            string categoriaMayorPromedio = null;
            float mayorPromedio = 0;
            List<Vehiculo> vehiculosCategoriaMayorPromedio = new List<Vehiculo>();

            foreach (var categoria in categorias)
            {
                var vehiculosCategoria = db.Vehiculo.Where(v => v.Categoria == categoria).ToList();

                float sumaPromedios = 0;
                int count = 0;

                foreach (var vehiculo in vehiculosCategoria)
                {
                    var calificacion = db.Calificacion.FirstOrDefault(c => c.VehiculoID == vehiculo.VehiculoID);
                    if (calificacion != null)
                    {
                        float promedio = (calificacion.proteccionFrontal + calificacion.proteccionLateral +
                                          calificacion.proteccionInfantil + calificacion.proteccionPeaton +
                                          calificacion.sistemasSeguridad) / 5;
                        sumaPromedios += promedio;
                        count++;
                    }
                }

                if (count > 0)
                {
                    float promedioCategoria = sumaPromedios / count;
                    if (promedioCategoria > mayorPromedio)
                    {
                        mayorPromedio = promedioCategoria;
                        categoriaMayorPromedio = categoria;
                        vehiculosCategoriaMayorPromedio = vehiculosCategoria;
                    }
                }
            }

            ViewBag.CategoriaMayorPromedio = categoriaMayorPromedio;
            ViewBag.Vehiculos = vehiculosCategoriaMayorPromedio;

            return View("Reporte");
        }


    }
    public class ComparativaCampo
    {
        public string Nombre { get; set; }
        public string ValorVehiculo1 { get; set; }
        public string ValorVehiculo2 { get; set; }
        public string ImagenUrlVehiculo1 { get; set; } // Propiedad de URL de imagen para Vehículo 1
        public string ImagenUrlVehiculo2 { get; set; } // Propiedad de URL de imagen para Vehículo 2

        public ComparativaCampo(string nombre, string valorVehiculo1, string valorVehiculo2, string imagenUrlVehiculo1, string imagenUrlVehiculo2)
        {
            Nombre = nombre;
            ValorVehiculo1 = valorVehiculo1;
            ValorVehiculo2 = valorVehiculo2;
            ImagenUrlVehiculo1 = imagenUrlVehiculo1;
            ImagenUrlVehiculo2 = imagenUrlVehiculo2;
        }
    }

}