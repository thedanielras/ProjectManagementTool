using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewModels
{
    public class AccountsSingInViewModel
    {

        public AccountsSingInViewModel(bool isSuccessfull, string errorMessage)
        {
            IsSuccessful = isSuccessfull;
            ErrorMessage = errorMessage;
        }
        public bool IsSuccessful { get; private set; }
        public string ErrorMessage { get; private set; }
    }
}
