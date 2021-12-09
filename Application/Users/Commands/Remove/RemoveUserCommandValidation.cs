using FluentValidation;

namespace Application.Users.Remove
{
    public class RemoveUserCommandValidation : AbstractValidator<RemoveUserCommand>
    {
        public RemoveUserCommandValidation()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("User id not provided.");
        }
    }
}