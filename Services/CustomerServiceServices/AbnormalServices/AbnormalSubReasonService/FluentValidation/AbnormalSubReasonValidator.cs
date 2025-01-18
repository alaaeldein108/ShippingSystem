using Data.Entities.Enums;
using FluentValidation;
using Services.CustomerServiceServices.AbnormalServices.AbnormalSubReasonService.Dto;

namespace Services.CustomerServiceServices.AbnormalServices.AbnormalSubReasonService.FluentValidation
{
    public class AbnormalSubReasonValidator : AbstractValidator<AbnormalSubReasonDto>
    {
        public AbnormalSubReasonValidator()
        {
            RuleFor(x => x.Type)
           .NotEmpty().WithMessage("Type is required.")
           .MaximumLength(200).WithMessage("Type cannot exceed 200 characters.");

            RuleFor(x => x.Status)
            .Must(status => status == null || Enum.IsDefined(typeof(StatusEnum), status))
            .WithMessage("Status must be null or a valid enum value.");




        }
    }
}
