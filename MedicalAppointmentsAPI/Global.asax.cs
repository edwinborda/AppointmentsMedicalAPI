using System.Web.Http;

namespace MedicalAppointmentsAPI
{
    public class Global : System.Web.HttpApplication
    { 

        protected void Application_Start()
        {
            IocConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}