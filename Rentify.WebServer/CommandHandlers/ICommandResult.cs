namespace Rentify.WebServer.CommandHandlers
{
    public interface ICommandResult
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        string FailureMessage { get; }
    }
}