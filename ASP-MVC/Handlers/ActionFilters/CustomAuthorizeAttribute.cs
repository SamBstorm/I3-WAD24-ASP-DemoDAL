using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_MVC.Handlers.ActionFilters
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString(nameof(SessionManager.ConnectedUser)) is null)
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
        }
    }
}
