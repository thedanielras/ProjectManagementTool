using FluentValidation;

namespace Application.Users.Commands.Edit
{
    public class EditUserCommandValidation : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidation()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("User id not provided");
            RuleFor(c => c.Name).NotEmpty().WithMessage("User Name is required");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(c => c.RoleId).NotEmpty().WithMessage("User role is required");
        }
    }
}