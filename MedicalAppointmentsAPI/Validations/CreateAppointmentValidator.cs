using FluentValidation;
using MedicalAppointmentsAPI.WebService;
using RestSharp;
using System;

namespace MedicalAppointmentsAPI.Validations
{
    public class CreateAppointmentValidator : AbstractValidator<CreateAppointments>
    {
        private RestClient client = new RestClient("http://pruebas.apimedic.personalsoft.net:8082/api/v1");

        public CreateAppointmentValidator()
        {
            RuleFor(c => c.doctorId)
                .NotEmpty().WithMessage("The doctor id can't be blank.")
                .Must(MedicalWebServices.ExistsDoctor).WithMessage("The doctor id doesn't exists in the medical's System");



            RuleFor(c => c.patientId)
                .NotEmpty().WithMessage("The patient id can't be blank.")
                .Must(MedicalWebServices.ExistsPatient).WithMessage("The patient id doesn't exists in the medical's System");
                
            
            RuleFor(c => c.assingmentDate)
                .NotEmpty().WithMessage("The assingment date can't be blank.")
                .Must(ValidatorTools.BeAValidDate).WithMessage("Invalid date and time")
                .Must(ValidatorTools.BeInValidDateRange).WithMessage("Date isn't in valid range");
        }
        
          
        
    }
}