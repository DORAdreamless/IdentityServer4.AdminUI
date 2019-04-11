using FluentValidation;

namespace IdentityServer4.Admin.Api.Domains.Clients
{
  

    public class ClientValidator : AbstractValidator<ClientDto>
    {
        public ClientValidator()
        {
            this.RuleSet("name", () =>
            {
                this.RuleFor(x => x.ClientId).NotEmpty().WithMessage("客户端ID不能为空。");
            });
            this.RuleSet("basic", () =>
            {
                this.RuleFor(x => x.ClientName).NotEmpty().WithMessage("客户端ID不能为空。");
            });
            this.RuleSet("authoriztion", () =>
            {

            });
            this.RuleSet("token", () =>
            {

            });
            this.RuleSet("token1", () =>
            {

            });
            this.RuleSet("device_flow", () =>
            {

            });
        }
    }
}
