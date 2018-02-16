using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;
using MedicalAppointmentsAPI.WebService;
using System.Linq;

namespace MedicalAppointmentsAPI.Controllers
{
    [RoutePrefix("api/v1/appointments")]
    public class AssignmentController : ApiController
    {
        private readonly IAssignmentServices assignmentServices;
        public AssignmentController(IAssignmentServices assignmentServices)
        {
            this.assignmentServices = assignmentServices;
        }

        /// <summary>
        /// Gets the availability of the doctor in a range of time
        /// </summary>
        /// <param name="id">Doctor Id</param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("doctors/{id:int}/availables")]
        [HttpPost]
        public IHttpActionResult getDoctorTimeFree(int id, [FromBody]TimeFreeModel entity)
        {
            try
            {
                if (entity == null)
                    ModelState.AddModelError("Entity", "First set the entity");

                if (!MedicalWebServices.ExistsDoctor(id))
                    ModelState.AddModelError("Id", "The doctor Id doesn't exists in a Medical System");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var lstTimeFree = assignmentServices.getTimeFreeByDoctorID(id, Convert.ToDateTime(entity.InitialDate), Convert.ToDateTime(entity.EndDate));

                return Ok(lstTimeFree);
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }


        }

        /// <summary>
        /// Get medical appointments assigned to a doctor
        /// </summary>
        /// <param name="id">Doctor Id</param>
        /// <returns></returns>
        [Route("doctors/{id:int}/assigned")]
        [HttpGet]
        public IHttpActionResult getAssignedDoctor(int id)
        {
            try
            {
                if (!MedicalWebServices.ExistsDoctor(id))
                    ModelState.AddModelError("Id", "The doctor Id doesn't exists in a Medical System");

                var result = assignmentServices.getAssignmentByDoctor(id);

                if (!result.Any())
                    return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        


        }
    }
}
