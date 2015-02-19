namespace Rentify.Core.Results
{
    public interface IResult
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        string FailureMessage { get; }
    }

    public interface IResult<out T> : IResult
    {
        T Result { get; }
    }
}