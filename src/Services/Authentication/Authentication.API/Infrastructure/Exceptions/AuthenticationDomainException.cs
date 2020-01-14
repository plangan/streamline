using System;

namespace Authentication.API.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class AuthenticationDomainException : Exception
    {
        public AuthenticationDomainException()
        { }

        public AuthenticationDomainException(string message)
            : base(message)
        { }

        public AuthenticationDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}