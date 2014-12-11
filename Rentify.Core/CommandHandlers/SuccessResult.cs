namespace Rentify.Core.CommandHandlers
{
    public class SuccessResult : ICommandResult
    {
        public SuccessResult() { }
        public SuccessResult(object result)
        {
            Result = result;
        }

        public bool IsSuccess { get { return true; } }
        public bool IsFailure { get { return false; }}
        public string FailureMessage { get { return string.Empty; } }

        public object Result { get; set; }
    }
}