using FluentValidation;

namespace Application.Users.Commands.AdminCreate
{
    public class AdminCreateUserCommandValidation : AbstractValidator<AdminCreateUserCommand>
    {
        public AdminCreateUserCommandValidation()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("User Name is required");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(c => c.RoleId).NotEmpty().WithMessage("User role is required");
        }
    }

}