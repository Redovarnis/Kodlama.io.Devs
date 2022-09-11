using FluentValidation;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().NotNull().WithMessage("Name must not be empty");
            RuleFor(u => u.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
