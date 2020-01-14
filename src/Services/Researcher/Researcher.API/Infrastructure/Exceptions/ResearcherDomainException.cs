using System;

namespace Researcher.API.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class ResearcherDomainException : Exception
    {
        public ResearcherDomainException()
        { }

        public ResearcherDomainException(string message)
            : base(message)
        { }

        public ResearcherDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}