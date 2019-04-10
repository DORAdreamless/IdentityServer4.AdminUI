using FluentValidation;

namespace IdentityServer4.Admin.Api.Domains.Clients
{
    public class CreateClientValidator : AbstractValidator<CreateClientModel>
    {
        public CreateClientValidator()
        {
            this.RuleFor(x => x.ClientUri).NotEmpty().WithMessage("clientid is not empty!");
        }
    }
}
