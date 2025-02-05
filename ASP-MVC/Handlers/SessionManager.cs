using ASP_MVC.Models.Cocktail;
using System.Text.Json;

namespace ASP_MVC.Handlers
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }

        public int CountVisitedPage
        {
            get { return _session.GetInt32(nameof(CountVisitedPage)) ?? 0 ; }
            set { _session.SetInt32(nameof(CountVisitedPage), value); }
        }

        public ConnectedUser? ConnectedUser
        {
            get { return JsonSerializer.Deserialize<ConnectedUser?>(_session.GetString(nameof(ConnectedUser)) ?? "null"); }
            set { 
                if(value is null)
                {
                    _session.Remove(nameof(ConnectedUser));
                }
                else
                {
                    _session.SetString(nameof(ConnectedUser), JsonSerializer.Serialize(value));
                }
            }
        }

        public IEnumerable<CocktailListItemMin> RecentlyVisitedCocktails
        {
            get {
                string? json = _session.GetString(nameof(RecentlyVisitedCocktails));
                if (json is null) return new CocktailListItemMin[0];
                return JsonSerializer.Deserialize<CocktailListItemMin[]>(json);
            }
            private set
            {
                string json = JsonSerializer.Serialize(value);
                _session.SetString(nameof(RecentlyVisitedCocktails), json);
            }
        }

        public void Login(ConnectedUser user)
        {
            ConnectedUser = user;
        }

        public void Logout() {
            ConnectedUser = null;
        }

        public void AddVisitedCocktail(CocktailListItemMin cocktail)
        {
            // Ligne permettant d'insérer le cocktail
            List<CocktailListItemMin> cocktails = new List<CocktailListItemMin>(RecentlyVisitedCocktails);
            CocktailListItemMin? cocktailInList = cocktails.Where(c => c.Cocktail_Id == cocktail.Cocktail_Id).SingleOrDefault();
            if(cocktailInList is not null)
            {
                cocktails.Remove(cocktailInList);
            }
            if(cocktails.Count == 5)
            {
                cocktails.Remove(cocktails[4]);
            }
            cocktails.Insert(0, cocktail);
            RecentlyVisitedCocktails = cocktails;
        }

        public void AddVisitedCocktail(Guid cocktail_id, string cocktail_name)
        {
            CocktailListItemMin cocktail = new CocktailListItemMin() { 
                Cocktail_Id = cocktail_id,
                Name = cocktail_name
            };
            AddVisitedCocktail(cocktail);
        }
    }
}
