using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace ASP_MVC.Handlers.ActionFilters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AdminNeededAttribute : Attribute, IAuthorizationFilter
    {
        private string[] _authorizedRoles;
        public AdminNeededAttribute() : this("Admin") { }
        public AdminNeededAttribute(params string[] authorizedRoles) { 
            _authorizedRoles = authorizedRoles;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? json = context.HttpContext.Session.GetString(nameof(SessionManager.ConnectedUser));
            if (json is null)
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
                return;
            }
            ConnectedUser user = JsonSerializer.Deserialize<ConnectedUser>(json);
            if (!_authorizedRoles.Contains(user.Role))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
