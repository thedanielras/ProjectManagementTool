using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetDetails
{
    public class GetUserDetailsQueryValidation : AbstractValidator<GetUserDetailsQuery>
    {

        public GetUserDetailsQueryValidation()
        {
            RuleFor(q => q.UserId).NotEmpty().WithMessage("Provided id is not valid.");
        }

    }
}
