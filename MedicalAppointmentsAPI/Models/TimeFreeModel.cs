using FluentValidation.Attributes;
using MedicalAppointmentsAPI.Validations;
using System.ComponentModel.DataAnnotations;


namespace MedicalAppointmentsAPI
{
    [Validator(typeof(TimeFreeValidator))]
    public class TimeFreeModel
    {
        /// <summary>
        /// Initial date from a range
        /// </summary>
        [Required]
        public string InitialDate { get; set; }

        /// <summary>
        /// Final date from a range
        /// </summary>
        [Required]
        public string EndDate { get; set; }
    }
}