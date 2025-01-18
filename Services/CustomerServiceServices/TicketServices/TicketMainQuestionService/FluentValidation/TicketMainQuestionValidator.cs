using Data.Entities.Enums;
using FluentValidation;
using Services.CustomerServiceServices.TicketServices.TicketMainQuestionService.Dto;

namespace Services.CustomerServiceServices.TicketServices.TicketMainQuestionService.FluentValidation
{
    public class TicketMainQuestionValidator : AbstractValidator<TicketMainQuestionDto>
    {
        public TicketMainQuestionValidator()
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
