namespace Storyteller.Application.Validation
{

    public class HandlerResult
    {
        public HandlerError Error { get; set; }
        public bool IsSuccess => Error == null;
        public bool IsFailure => Error != null;
        public object Value { get; set; }
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

        public static HandlerResult Sucess(object value)
        {
            return new HandlerResult
            {
                Value = value
            };
        }
    }

    public class HandlerResult<T> : HandlerResult
    {
        public static HandlerResult<T> Failure(string code, string message)
        {
            return (HandlerResult<T>)HandlerResult.Failure(code, message);
        }

        public static HandlerResult<T> Success(T value)
        {
            var result = HandlerResult.Sucess(value);
            return new HandlerResult<T>
            {
                Value = (T)result.Value
            };
        }
    }

    public class HandlerResultEmpty : HandlerResult
    {
        public static HandlerResultEmpty Success()
        {
            return new HandlerResultEmpty();
        }
    }
}
