namespace Rentify.WebServer.CommandHandlers
{
    public class FailureResult : ICommandResult
    {
        public FailureResult(string failureMessage)
        {
            FailureMessage = failureMessage;
        }

        public bool IsSuccess { get { return false; } }
        public bool IsFailure { get { return true; } }
        public string FailureMessage { get; private set; }
    }
}