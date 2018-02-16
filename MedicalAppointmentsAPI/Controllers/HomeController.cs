using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MedicalAppointmentsAPI.Controllers
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [Route("v1")]
        [HttpGet]
        public IHttpActionResult getEnpoints()
        {
            var dictionary = new Dictionary<string, string>() {
                {
                    "rest_appointment",
                    $"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Authority}/api/v1/appointments"
                },
                {
                    "doctor_ssingment",
                    $"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Authority}/api/v1/appointments/doctor/[id:int]/assigned"
                },
                {
                    "doctor_available",
                    $"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Authority}/api/v1/appointments/doctor/[id:int]/available"
                }
            };

            return Ok(dictionary);
        }
    }
}
