

using FluentValidation.Attributes;
using MedicalAppointmentsAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsAPI
{
    [Validator(typeof(CreateAppointmentValidator))]
    public class CreateAppointments
    {
        [Required]
        public string assingmentDate { get; set; }

        [Required]
        public int patientId { get; set; }

        [Required]
        public int doctorId { get; set; }
    }
}