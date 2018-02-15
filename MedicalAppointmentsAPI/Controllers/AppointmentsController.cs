using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalAppointmentsAPI.Controllers
{
    [RoutePrefix("api/appointments")]
    public class AppointmentsController : ApiController
    {
        private readonly IAppointmentServices appointmentsServices;
        public AppointmentsController(IAppointmentServices appointmentsServices)
        {
            this.appointmentsServices = appointmentsServices;
        }

        /// <summary>
        /// Get all active Medical appointments
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]

        public IHttpActionResult getAll()
        {

            var listAppointments = appointmentsServices.getAllAppointments();

            if (!listAppointments.Any())
                return NotFound();

            return Ok(listAppointments);
        }

        /// <summary>
        /// get Medical appointment by id
        /// </summary>
        /// <param name="id">Medical appointment Id</param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult getAppointment(int id)
        {
            try
            {
                var appointment = appointmentsServices.getAppointmentById(id);

                return Ok(appointment);
            }
            catch
            {
                return NotFound();

            }
        }

        /// <summary>
        /// Create a medical appointment
        /// </summary>
        /// <param name="assingmentDate">Assigment Date </param>
        /// <param name="patientId">Patient Id</param>
        /// <param name="doctorId">Doctor Id</param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public IHttpActionResult createAppointment([FromBody]CreateAppointments entity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                appointmentsServices.createAppointment(Convert.ToDateTime(entity.assingmentDate), entity.patientId, entity.doctorId);

                return Ok();
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Re assigns a medical appointment and changes the doctor if necessary
        /// </summary>
        /// <param name="id">AppointmentId</param>
        /// <param name="reassigmentDate">Re-assingment date</param>
        /// <param name="doctorId">Doctor Id</param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult modifyAppointment(int id, [FromBody]ReAssingmentAppointment entity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                appointmentsServices.modifyAppointment(Convert.ToDateTime(entity.reassigmentDate), id, entity.doctorId);

                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Cancel a medical appointment
        /// </summary>
        /// <param name="id">Appointment Id</param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult cancelAppointment(int id)
        {
            try
            {
                appointmentsServices.cancelAppointment(id);

                return Ok();
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }
        }

    }
}
