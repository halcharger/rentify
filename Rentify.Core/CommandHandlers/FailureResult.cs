using System.Linq;
using System.Web.Http.ModelBinding;
using NExtensions;

namespace Rentify.Core.CommandHandlers
{
    public class FailureResult : ICommandResult
    {
        public FailureResult(string failureMessage)
        {
            FailureMessage = failureMessage;
        }

        public FailureResult(string parameterisedFailureMessage, params object[] parameters)
        {
            FailureMessage = string.Format(parameterisedFailureMessage, parameters);
        }

        public FailureResult(ModelStateDictionary state)
        {
            FailureMessage = state.Values.SelectMany(v => v.Errors)
                                         .Select(me => me.ErrorMessage)
                                         .ToArray()
                                         .JoinWithNewLine();
        }

        public bool IsSuccess { get { return false; } }
        public bool IsFailure { get { return true; } }
        public string FailureMessage { get; private set; }

        public object Result { get; set; }
    }
}