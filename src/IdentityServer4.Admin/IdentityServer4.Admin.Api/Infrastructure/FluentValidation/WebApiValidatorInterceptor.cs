using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IdentityServer4.Admin.Api.Infrastructure.FluentValidation
{
    public class WebApiValidatorInterceptor : IValidatorInterceptor
    {
        public ValidationResult AfterMvcValidation(ControllerContext controllerContext, ValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {
                string message = result.Errors.First().ErrorMessage;
                throw new FluentValidationException(message);
            }

            return result;
        }

        public ValidationContext BeforeMvcValidation(ControllerContext controllerContext, ValidationContext validationContext)
        {
            return validationContext;
        }
    }
}
