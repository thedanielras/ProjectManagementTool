using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetByNameAndPassword
{
    public class GetUserByNameAndPasswordQueryValidator : AbstractValidator<GetUserByNameAndPasswordQuery>
    {
        public GetUserByNameAndPasswordQueryValidator()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("User Name is required");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
