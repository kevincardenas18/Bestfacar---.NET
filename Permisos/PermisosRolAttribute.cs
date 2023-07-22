using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaBestfacar.Models;

namespace PruebaBestfacar.Permisos
{
    public class PermisosRolAttribute : ActionFilterAttribute
    {
        private Rol idRol;

        public PermisosRolAttribute(Rol Rol)
        {
            idRol = Rol;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(HttpContext.Current.Session["Usuarios"] != null)
            {
                Usuarios usuarios = HttpContext.Current.Session["Usuarios"] as Usuarios;
                if(usuarios.IdRol !=this.idRol)
                {
                    filterContext.Result = new RedirectResult("~/Home/NoAutorizado");
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}