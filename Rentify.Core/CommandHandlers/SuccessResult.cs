namespace Rentify.Core.CommandHandlers
{
    public class SuccessResult : ICommandResult
    {
        public bool IsSuccess { get { return true; } }
        public bool IsFailure { get { return false; }}
        public string FailureMessage { get { return string.Empty; } }
    }
}