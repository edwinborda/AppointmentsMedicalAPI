using FluentValidation;
using RestSharp;
using System;
using MedicalAppointmentsAPI.WebService;

namespace MedicalAppointmentsAPI.Validations
{
    public class ReAssignmentAppointmentValidator : AbstractValidator<ReAssingmentAppointment>
    {
        private RestClient client = new RestClient("http://pruebas.apimedic.personalsoft.net:8082/api/v1");
        public ReAssignmentAppointmentValidator()
        {
            RuleFor(r => r.reassigmentDate)
                .NotEmpty().WithMessage("The re-assingment date can't be blank.")
                .Must(ValidatorTools.BeAValidDate).WithMessage("Invalid Date and time")
                .Must(ValidatorTools.BeInValidDateRange).WithMessage("Date isn't in valid range"); 

            RuleFor(r => r.doctorId)
                .Must(MedicalWebServices.ExistsDoctor).When(r => r.doctorId > 0).WithMessage("The doctor id doesn't exists in the medical's System");
        }

        
    }
}