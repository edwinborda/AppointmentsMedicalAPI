
using FluentValidation.Attributes;
using MedicalAppointmentsAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsAPI
{
    [Validator(typeof(ReAssignmentAppointmentValidator))]
    public class ReAssingmentAppointment
    {
        /// <summary>
        /// Medical appointment re-assignment date
        /// </summary>
        public string reassigmentDate { get; set; }
        
        /// <summary>
        /// Doctor Id
        /// </summary>
        public int doctorId { get; set; } = 0;
    }
}