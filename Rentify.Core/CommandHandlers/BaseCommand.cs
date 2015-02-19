using System;

namespace Rentify.Core.CommandHandlers
{
    public class BaseCommand
    {
        public BaseCommand()
        {
            DateTime = DateTime.UtcNow;
        }

        public string UserId { get; set; }
        public DateTime DateTime { get; protected set; }
    }
}