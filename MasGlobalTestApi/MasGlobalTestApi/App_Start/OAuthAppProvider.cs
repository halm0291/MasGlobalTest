using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MasGlobalTestApi.App_Start
{
    public partial class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        private string clientSecret;
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            
            context.TryGetFormCredentials(out clientId, out clientSecret);
            if (!string.IsNullOrEmpty(clientId))
            {
                context.Validated(clientId);
            }
            else
            {
                context.Validated();
            }
            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    bool isValid = false;
                    isValid = context.ClientId == "1235" && clientSecret == "6779ef20e75817b79602" ? true : false;
     
                    if (isValid)
                    {
                        var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                        oAuthIdentity.AddClaim(new Claim("ClientID", context.ClientId));
                        var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
                        context.Validated(ticket);
                    }
                    else
                    {
                        context.SetError("Error", "Credentials not valid");
                    }
                }
                catch (Exception)
                {
                    context.SetError("Error", "internal server error");
                }
            });
        }
    }
}