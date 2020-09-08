using System;

namespace MarconnetDotFr.Core.Exceptions
{
    public class WorkNotKnownException : Exception
    {
        public WorkNotKnownException(string message) : base(message)
        {
        }
    }
}
