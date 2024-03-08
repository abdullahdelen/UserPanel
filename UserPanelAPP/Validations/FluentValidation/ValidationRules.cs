using FluentValidation;
using UserPanelAPP.Models;

namespace UserPanelAPP.Validations.FluentValidation
{
    public class ValidationRules:AbstractValidator<User>
    {
        public ValidationRules()    
        {
            RuleFor(user => user.Tcno).NotEmpty().WithMessage("TCNo cannot be empty").MaximumLength(11).WithMessage("TCNo must be 11 character");
            RuleFor(user => user.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(user => user.Surname).NotEmpty().WithMessage("Surname cannot be empty");
            RuleFor(user => user.BirthDate).NotEmpty().WithMessage("Birthdate cannot be empty");

           
            RuleFor(user => user.BirthDate).Must(BeAValidDate).When(user => user.BirthDate != null)
                                             .WithMessage("BirthDate must be a valid date.");

            RuleFor(user => user.UpdatedDate).Must(BeAValidDate).When(user => user.UpdatedDate != null)
                                               .WithMessage("UpdatedDate must be a valid date.");
        }

        private bool BeAValidDate(DateOnly? date)
        {
            
            return date != null && date.HasValue && date.Value != default(DateOnly);
        }
    }
}
