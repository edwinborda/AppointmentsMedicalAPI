using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;
using MedicalAppointmentsAPI.Controllers;
using MedicalAppointmentsAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace MedicalAppointment.Test
{
    [TestClass]
    public partial class AppointmentIntregationTest
    {
        private const string url = "http://localhost/api/v1/appointments";

        [TestMethod]
        public async Task ShouldGetAppointments()
        {
            var appointmentController = new AppointmentsController(new Services.AppointmentServices())
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{url}")
                }
            };

            appointmentController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var response = appointmentController.getAll();
            var result = await response.ExecuteAsync(new System.Threading.CancellationToken());
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task ShouldGetAppointmentsById()
        {
            var appointment = 1;

            var appointmentController = new AppointmentsController(new Services.AppointmentServices())
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{url} /{appointment}")
                }
            };

            appointmentController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var response = appointmentController.getAppointment(appointment);
            var result = await response.ExecuteAsync(new System.Threading.CancellationToken());
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task ShouldCreateAppointment()
        {
            var body = new CreateAppointments()
            {
                assignmentDate = DateTime.Now.AddDays(1).ToShortDateString(),
                patientId = 11,
                doctorId = 3
            };

            var appointmentController = new AppointmentsController(new Services.AppointmentServices())
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"),
                    RequestUri = new Uri($"{url}")
                }
            };

            appointmentController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var response = appointmentController.createAppointment(body);
            var result = await response.ExecuteAsync(new System.Threading.CancellationToken());
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task ShouldModifyAppointment()
        {
            var appointment = 1;
            var body = new ReAssingmentAppointment()
            {
                reassigmentDate = DateTime.Now.AddDays(1).ToShortDateString(),
                doctorId = 3
            };

            var appointmentController = new AppointmentsController(new Services.AppointmentServices())
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"),
                    RequestUri = new Uri($"{url}/{appointment}")
                }
            };

            appointmentController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var response = appointmentController.modifyAppointment(appointment, body);
            var result = await response.ExecuteAsync(new System.Threading.CancellationToken());
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task ShouldCancelAppointment()
        {
            var appointment = 1;

            var appointmentController = new AppointmentsController(new Services.AppointmentServices())
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri($"{url} /{appointment}")
                }
            };

            appointmentController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var response = appointmentController.cancelAppointment(appointment);
            var result = await response.ExecuteAsync(new System.Threading.CancellationToken());
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task ShouldGetAvailabityDoctor()
        {
            var doctorId = 3;
            var body = new TimeFreeModel()
            {
                InitialDate = "1900-01-01T08:00:00",
                EndDate = "1900-01-01T17:00:00"
            };
            var assignmentController = new AssignmentController(new Services.assignmentServices())
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"),
                    RequestUri = new Uri($"{url}/doctors/{doctorId}/availables")
                }
            };

            assignmentController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var response = assignmentController.getDoctorTimeFree(doctorId, body);
            var result = await response.ExecuteAsync(new System.Threading.CancellationToken());
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task ShouldGetAssignmentDoctor()
        {
            var doctorId = 3;
            var assignmentController = new AssignmentController(new Services.assignmentServices())
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,

                    RequestUri = new Uri($"{url}/doctors/{doctorId}/assigned")
                }
            };

            assignmentController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var response = assignmentController.getAssignedDoctor(doctorId);
            var result = await response.ExecuteAsync(new System.Threading.CancellationToken());
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

        }
    }
}
