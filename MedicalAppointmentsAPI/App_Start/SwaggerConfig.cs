using System.Web.Http;
using WebActivatorEx;
using MedicalAppointmentsAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MedicalAppointmentsAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "MedicalAppointmentsAPI");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\MedicalAppointmentsAPI.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                    })
                .EnableSwaggerUi();
        }
    }
}
