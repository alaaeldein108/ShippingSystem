using FluentValidation;
using Services.CustomerServiceServices.AbnormalServices.AbnormalService.Dto;

namespace Services.CustomerServiceServices.AbnormalServices.AbnormalService.FluentValidation
{
    public class AbnormalValidator : AbstractValidator<AbnormalDto>
    {
        public AbnormalValidator()
        {
            RuleFor(x => x.AbnormalSubReasonId)
           .GreaterThan(0)
           .WithMessage("AbnormalSubReasonId must be greater than 0.");

            RuleFor(x => x.OrderNumber)
                .NotEmpty()
                .WithMessage("OrderNumber is required.");

            RuleFor(x => x.ProblemDescription)
                .NotEmpty()
                .WithMessage("ProblemDescription is required.")
                .MaximumLength(500)
                .WithMessage("ProblemDescription must not exceed 500 characters.");

            RuleFor(x => x.AbnormalStatus)
                .IsInEnum()
                .WithMessage("Invalid AbnormalStatus value.");

            RuleFor(x => x.RegisterId)
                .NotEmpty()
                .WithMessage("RegisterId is required.");

            RuleFor(x => x.AbnormalImages)
                .NotNull()
                .WithMessage("AbnormalImages cannot be null.")
                .Must(images => images.Count > 0)
                .WithMessage("At least one image is required.");

            RuleForEach(x => x.AbnormalImages)
                .Must(image => image.Length > 0)
                .WithMessage("Each image must have a valid file size.");

            RuleFor(x => x.AbnormalReplies)
                .Must(replies => replies == null || replies.All(id => id != Guid.Empty))
                .WithMessage("All AbnormalReplies must be valid GUIDs.");
        }

    }
}

