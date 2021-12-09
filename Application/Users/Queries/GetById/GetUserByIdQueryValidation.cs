using FluentValidation;

namespace Application.Users.Queries.GetById
{
    public class GetUserByIdQueryValidation : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidation()
        {
            RuleFor(q => q.UserId).NotEmpty().WithMessage("User id not provided.");
        }
    }
}