
using System.Web.Http;

namespace ServicioAPI
{
    /// <summary>
    ///     Clase Web Api Aplicación
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        ///     Función Incio de Aplicación
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            //Incluye la configuración de AutoMapper

            //Evito las referencias circulares al trabajar con Entity FrameWork         
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            //Elimino que el sistema devuelva en XML, sólo trabajaremos con JSON
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}
