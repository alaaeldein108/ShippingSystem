using Data.Entities.Enums;
using FluentValidation;
using Services.FinanceServices.ZoneService.Dto;

namespace Services.FinanceServices.ZoneService.FluentValidation
{
    public class ZoneValidator : AbstractValidator<ZoneDto>
    {
        public ZoneValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.ZoneType)
                .IsInEnum().WithMessage("ZoneType must be a valid enumeration value.");


            RuleFor(x => x.Status)
            .Must(status => status == null || Enum.IsDefined(typeof(StatusEnum), status))
            .WithMessage("Status must be null or a valid enum value.");

            RuleFor(x => x.QuotationType)
                .IsInEnum().WithMessage("QuotationType must be a valid enumeration value.");

            RuleFor(zone => zone.Cities)
            .NotNull().WithMessage("Cities cannot be null.")
            .Must(cities => cities.All(city => !string.IsNullOrWhiteSpace(city)))
            .WithMessage("Cities cannot contain null or empty values.")
            .Must(cities => cities.Count == cities.Distinct().Count())
            .WithMessage("Cities cannot contain duplicate values.");

        }
    }
}
