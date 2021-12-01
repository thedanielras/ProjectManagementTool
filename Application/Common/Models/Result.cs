using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Common.Models
{
    public enum ResultPayloadType : int
    { 
        Null = 0,
        Json = 1,
        Html = 2
    }
    public class Result
    {
        public Result(
                bool succeded,
                IEnumerable<String> errors,
                object payload,
                ResultPayloadType resultPayloadType = ResultPayloadType.Null
            )
        {
            Succeded = succeded;
            Errors = errors.ToArray();
            Payload = payload;
            ResultPayloadType = resultPayloadType;
        }

        public ResultPayloadType ResultPayloadType { get; set; }
        public object Payload { get; set; }
        public int MyProperty { get; set; }
        public bool Succeded { get; set; }
        public string[] Errors { get; set; }

        public static Result Success()
        {
            return new Result(true, new List<String>(), null);
        }

        public static Result SuccessWithJsonPayload(object payload) 
        {
            return new Result(true, new List<String>(), payload, ResultPayloadType.Json);
        }

        public static Result SuccessWithHtmlPayload(string payload) 
        {
            return new Result(true, new List<String>(), payload, ResultPayloadType.Html);
        }

        public static Result Error(IEnumerable<String> errors)
        {
            return new Result(false, errors, null, ResultPayloadType.Null);
        }
    }
}
