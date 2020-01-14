using System;

namespace Administration.API.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class AdministrationDomainException : Exception
    {
        public AdministrationDomainException()
        { }

        public AdministrationDomainException(string message)
            : base(message)
        { }

        public AdministrationDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}