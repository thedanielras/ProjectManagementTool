using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("User Name is required");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(u => u.RepeatPassword).NotEmpty().WithMessage("Reapeat password");
            RuleFor(u => u.RepeatPassword).Equal(u => u.Password).WithMessage("Passwords not matching");
        }

    }
}
