using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewModels
{

    public enum ResponseType: int
    { 
        OK = 0,
        KO = 1
    }

    public class ResponseViewModel
    {
        public ResponseViewModel(object payload, ResponseType responseType = ResponseType.OK, string errorMessage = "")
        {
            Payload = payload;
            ResponseType = responseType;
            ErrorMessage = errorMessage;            
        }

        public ResponseType ResponseType { get; set; }

        public string ErrorMessage { get; set; }

        public object Payload { get; set; }
    }
}
