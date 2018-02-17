using System.Web.Http;
using FluentValidation.WebApi;


namespace MedicalAppointmentsAPI
{
    public class Global : System.Web.HttpApplication
    { 

        protected void Application_Start()
        {
            IocConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration);
            
        }
    }
}