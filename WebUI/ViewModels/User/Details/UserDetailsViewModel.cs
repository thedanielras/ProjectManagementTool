using Application.Users.Queries.GetDetails;

namespace WebUI.ViewModels.User.Details
{
    public class UserDetailsViewModel
    {
        public GetUserDetailsUserDto User { get; }

        public UserDetailsViewModel(GetUserDetailsUserDto user)
        {
            User = user;
        }       
    }
}
