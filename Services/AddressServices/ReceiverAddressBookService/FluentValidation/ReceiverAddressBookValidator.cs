using FluentValidation;
using Services.AddressServices.ReceiverAddressBookService.Dto;

namespace Services.AddressServices.ReceiverAddressBookService.FluentValidation
{
    public class ReceiverAddressBookValidator : AbstractValidator<ReceiverAddressBookDto>
    {
        public ReceiverAddressBookValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.SecondPhone)
                .Matches(@"^\+?[1-9]\d{1,14}$").When(x => !string.IsNullOrEmpty(x.SecondPhone))
                .WithMessage("Invalid second phone number format.");

            RuleFor(x => x.AreaId)
                .NotEmpty().WithMessage("Area ID is required.");

            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street is required.")
                .MaximumLength(200).WithMessage("Street cannot exceed 200 characters.");

            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("Client ID is required.");



        }
    }
}
