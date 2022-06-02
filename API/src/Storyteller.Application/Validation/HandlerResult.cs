using Microsoft.AspNetCore.Mvc;

namespace Storyteller.Application.Validation
{

    public class HandlerResult
    {
        public HandlerError Error { get; set; }
        public bool IsSuccess => Error == null;
        public bool IsFailure => Error != null;

        public static HandlerResult Failure(string code, string message)
        {
            return new HandlerResult
            {
                Error = new HandlerError
                {
                    Code = code,
                    Message = message
                }
            };
        }
    }

    public class HandlerResult<T> : HandlerResult
    {
        public T Value { get; set; }

        public static HandlerResult Failure(string code, string message)
        {
            return HandlerResult.Failure(code, message);
        }

        public static HandlerResult<T> Success(T value)
        {
            return new HandlerResult<T>
            {
                Value = value,
            };
        }
    }
}
