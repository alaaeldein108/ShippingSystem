using Data.Entities.Enums;
using FluentValidation;
using Services.CustomerServiceServices.TicketServices.TicketSubQuestionService.Dto;

namespace Services.CustomerServiceServices.TicketServices.TicketSubQuestionService.FluentValidation
{
    public class TicketSubQuestionValidator : AbstractValidator<TicketSubQuestionDto>
    {
        public TicketSubQuestionValidator()
        {
            RuleFor(x => x.Type)
           .NotEmpty().WithMessage("Type is required.")
           .MaximumLength(100).WithMessage("Type cannot exceed 100 characters.");

            RuleFor(x => x.Status)
            .Must(status => status == null || Enum.IsDefined(typeof(StatusEnum), status))
            .WithMessage("Status must be null or a valid enum value.");


        }
    }
}
