using System.Data.Entity;
using System.Web.Http;
using TTAnalytics.Data;

namespace TTAnalytics.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            TTAnalyticsContext db = new TTAnalyticsContext();
            
            var teste = db.Country.ToListAsync().Result;
            var b = "";
        }
    }
}
