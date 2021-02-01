using System.Collections.Generic;

namespace Pricing.Calculator.Web.App.Models.Response
{
    public class OperationResult
    {
        public bool Successful { get; init; }

        public IDictionary<string, string[]>? Errors { get; init; }

        public static OperationResult Fail(IDictionary<string, string[]> errors)
        {
            return new OperationResult
            {
                Successful = false,
                Errors = errors
            };
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T? Data { get; init; }

        public static OperationResult<T> Success(T data)
        {
            return new OperationResult<T>
            {
                Successful = true,
                Data = data
            };
        }
    }
}
