using NExtensions;

namespace Rentify.Core.Results
{
    public class SimpleResult : IResult
    {
        protected bool isSuccess;
        protected string failureMessage;

        protected SimpleResult(string failureMessage)
        {
            isSuccess = false;
            this.failureMessage = failureMessage;
        }

        protected SimpleResult()
        {
            isSuccess = true;
        }

        public static SimpleResult Success()
        {
            return new SimpleResult();
        }

        public static SimpleResult Failure(string message)
        {
            return new SimpleResult(message);
        }

        public static SimpleResult Failure(string messageFormat, params object[] parameters)
        {
            return Failure(messageFormat.FormatWith(parameters));
        }

        public bool IsSuccess
        {
            get { return isSuccess; }
        }

        public bool IsFailure
        {
            get { return !isSuccess; }
        }

        public string FailureMessage
        {
            get { return failureMessage; }
        }
    }
    public class AResultOf<T> : SimpleResult, IResult<T>
    {
        private readonly T result;

        private AResultOf(string failureMessage) : base(failureMessage) { } 
        private AResultOf(T result)
        {
            isSuccess = true;
            this.result = result;
        }

        public static AResultOf<T> Success(T result)
        {
            return new AResultOf<T>(result);
        }

        public new static AResultOf<T> Failure(string message)
        {
            return new AResultOf<T>(message);
        }  

        public T Result
        {
            get { return result; }
        }
    }
}