using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace Ajf.RideShare.Web.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri;
                var returnUrl = context.Request.Query["returnUrl"];

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    expectedRootUri = new Uri(returnUrl);
                }
                else
                {
                    expectedRootUri = new Uri(context.Request.Uri, "/RideShare/");
                }

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
                else if (context.ClientId == "web")
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        var expectedUri = new Uri(returnUrl);
                        context.Validated(expectedUri.AbsoluteUri);
                    }
                    else
                    {
                        expectedRootUri = new Uri(context.Request.Uri, "/RideShare/");
                        context.Validated(expectedRootUri.AbsoluteUri);
                    }
                }
            }

            return Task.FromResult<object>(null);
        }
    }
}