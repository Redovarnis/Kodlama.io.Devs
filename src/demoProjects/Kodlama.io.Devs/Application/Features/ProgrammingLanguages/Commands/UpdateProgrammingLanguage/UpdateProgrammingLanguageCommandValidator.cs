using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().NotNull();
            RuleFor(u => u.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
