using System;

namespace Patient.API.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class PatientDomainException : Exception
    {
        public PatientDomainException()
        { }

        public PatientDomainException(string message)
            : base(message)
        { }

        public PatientDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}