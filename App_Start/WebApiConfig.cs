using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace PruebaBestfacar
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Remover el formateador de XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Agregar el formateador de JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
