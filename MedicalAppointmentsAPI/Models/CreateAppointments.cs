

using FluentValidation.Attributes;
using MedicalAppointmentsAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsAPI
{
    [Validator(typeof(CreateAppointmentValidator))]
    public class CreateAppointments
    {
        
        /// <summary>
        /// Medical appointment assignment Date
        /// </summary>
        public string assignmentDate { get; set; }

        /// <summary>
        /// Patient Id
        /// </summary>
        public int patientId { get; set; }

        /// <summary>
        /// Doctor Id
        /// </summary>
        public int doctorId { get; set; }
    }
}