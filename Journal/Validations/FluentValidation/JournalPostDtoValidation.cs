using FluentValidation;
using Journal.DTOs;

namespace Journal.Validations.FluentValidation
{
    public class JournalPostDtoValidation:AbstractValidator<JournalPostDto>
    {
        public JournalPostDtoValidation()
        {
            RuleFor(p=>p.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(55);
            RuleFor(p => p.Description).NotEmpty().NotNull().MinimumLength(5);
            RuleFor(p => p.PrintTime).NotEmpty().NotNull();
            RuleFor(p => p.Display).NotEmpty().NotNull();
        }
    }
}
