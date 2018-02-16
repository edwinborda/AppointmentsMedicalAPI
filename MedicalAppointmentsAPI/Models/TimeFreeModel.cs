using FluentValidation.Attributes;
using MedicalAppointmentsAPI.Validations;
using System.ComponentModel.DataAnnotations;


namespace MedicalAppointmentsAPI
{
    [Validator(typeof(TimeFreeValidator))]
    public class TimeFreeModel
    {
        [Required]
        public string InitialDate { get; set; }

        [Required]
        public string EndDate { get; set; }
    }
}