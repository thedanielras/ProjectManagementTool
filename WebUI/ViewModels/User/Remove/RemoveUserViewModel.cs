using Application.Users.Remove;

namespace WebUI.ViewModels.User.Remove
{
    public class RemoveUserViewModel
    {
        public RemoveUserDto User { get; }
        public RemoveUserViewModel(RemoveUserDto user)
        {
            User = user;
        }
    }
}