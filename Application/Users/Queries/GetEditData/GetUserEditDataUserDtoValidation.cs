using Application.Users.Queries.GetEditData;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetDetails
{
    public class GetUserEditDataUserDtoValidation : AbstractValidator<GetUserEditDataQuery>
    {

        public GetUserEditDataUserDtoValidation()
        {
            RuleFor(q => q.UserId).NotEmpty().WithMessage("Provided id is not valid.");
        }

    }
}
