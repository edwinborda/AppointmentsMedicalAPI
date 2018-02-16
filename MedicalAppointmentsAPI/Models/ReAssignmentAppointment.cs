
using FluentValidation.Attributes;
using MedicalAppointmentsAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentsAPI
{
    [Validator(typeof(ReAssignmentAppointmentValidator))]
    public class ReAssingmentAppointment
    {
        
        public string reassigmentDate { get; set; }
        
        public int doctorId { get; set; } = 0;
    }
}