using FluentValidation;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyValidator : AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(p => p.ProgrammingLanguageId).NotEmpty().NotNull();
            RuleFor(p => p.ProgrammingLanguageId).GreaterThan(0);
        }
    }
}
