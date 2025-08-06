using BediaX.Application.Destinations.Commands;
using FluentValidation;

namespace BediaX.Application.Destinations.Validators;

/// <summary>
/// Validator for the <see cref="UpdateDestinationCommand"/> request.
/// </summary>
public class UpdateDestinationCommandValidator : AbstractValidator<UpdateDestinationCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateDestinationCommandValidator"/> class
    /// and defines validation rules for updating a destination.
    /// </summary>
    public UpdateDestinationCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(150).WithMessage("Name cannot exceed 150 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.CountryId)
            .GreaterThan(0).WithMessage("CountryId must be greater than 0.");

        RuleFor(x => x.DestinationTypeId)
            .GreaterThan(0).WithMessage("DestinationTypeId must be greater than 0.");
    }
}