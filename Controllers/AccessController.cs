using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaBestfacar.Models;
using PruebaBestfacar.Logica;
using System.Web.Security;

namespace PruebaBestfacar.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            Usuarios objeto = new LOusuario().EncontrarUsuario(email,password);
            if(objeto.Nombre != null)
            {
                FormsAuthentication.SetAuthCookie(objeto.Email, false);
                Session["Usuarios"] = objeto;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}