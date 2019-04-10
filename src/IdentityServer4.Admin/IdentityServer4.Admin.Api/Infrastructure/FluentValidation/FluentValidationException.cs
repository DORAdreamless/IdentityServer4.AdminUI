using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Infrastructure.FluentValidation
{
    public class FluentValidationException : Exception
    {
        public FluentValidationException()
        {
        }

        public FluentValidationException(string message) : base(message)
        {
        }
    }
}
