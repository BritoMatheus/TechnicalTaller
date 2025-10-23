using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Taller.Attributes
{
    public class CustomHeaderAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "CustomHeader";
        public string HeaderName { get; set; } = "Authorization";
    }

    public class CustomHeaderAuthenticationHandler : AuthenticationHandler<CustomHeaderAuthenticationOptions>
    {
        public CustomHeaderAuthenticationHandler(
            IOptionsMonitor<CustomHeaderAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder)
            : base(options, logger, encoder)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(Options.HeaderName))
            {
                return AuthenticateResult.NoResult();
            }

            string headerValue = Request.Headers[Options.HeaderName].ToString();

            if (headerValue == "employee")
            {
                var claims = new[] { new Claim(ClaimTypes.NameIdentifier, headerValue) };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("Invalid custom header value.");
            }
        }
    }
}
