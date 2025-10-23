using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Taller.Attributes
{
    public class AuthenticationAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);

            if (token != "employee")
            {
                context.Result = new ForbidResult();
            }

            return Task.CompletedTask;
        }
    }
}
