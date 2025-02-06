using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace ASP_MVC.Handlers.ActionFilters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class IsCreatorAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? json = context.HttpContext.Session.GetString(nameof(SessionManager.ConnectedUser));
            if (json is null)
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
                return;
            }
            ConnectedUser connectedUser = JsonSerializer.Deserialize<ConnectedUser>(json);
            Guid cocktail_id = Guid.Parse(context.RouteData.Values["id"].ToString());
            ICocktailRepository<Cocktail> cocktailRepository = GetCocktailService(context.HttpContext);
            Cocktail cocktail = cocktailRepository.Get(cocktail_id);
            if(cocktail.CreatedBy != connectedUser.User_Id)
            {
                context.Result = new RedirectToActionResult("Details", "Cocktail", new { id = cocktail_id });
            }
        }

        private ICocktailRepository<Cocktail> GetCocktailService(HttpContext httpContext)
        {
            IServiceProvider serviceProvider = httpContext.RequestServices;
            return serviceProvider.GetService<ICocktailRepository<Cocktail>>();
        }
    }
}
