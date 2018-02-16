using FluentValidation;

namespace MedicalAppointmentsAPI.Validations
{
    public class TimeFreeValidator : AbstractValidator<TimeFreeModel>
    {
        public TimeFreeValidator()
        {
            RuleFor(t => t.InitialDate)
                    .NotNull().WithMessage("The initial Date can't be blank")
                    .NotEmpty().WithMessage("The initial Date can't be blank.")
                    .Must(ValidatorTools.BeAValidDate).WithMessage("Invalid Date and Time");

            RuleFor(t => t.EndDate)
                    .NotNull().WithMessage("The end Date can't be blank.")
                    .NotEmpty().WithMessage("The end Date can't be blank.")
                    .Must(ValidatorTools.BeAValidDate).WithMessage("Invalid Date and Time");
        }
    }
}