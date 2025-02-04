using Common.Repositories;

namespace ASP_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Ajout d'implémentation des services nécessaires ŕ l'utilisation de session :
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(
                options => {
                    options.Cookie.Name = "CookieWad24";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                    options.IdleTimeout = TimeSpan.FromMinutes(10);
                });
            builder.Services.Configure<CookiePolicyOptions>(options => { 
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });


            //Ajout de nos services : Ceux de la BLL et ceux de la DAL
            builder.Services.AddScoped<IUserRepository<BLL.Entities.User>, BLL.Services.UserService>();
            builder.Services.AddScoped<IUserRepository<DAL.Entities.User>, DAL.Services.UserService>();
            builder.Services.AddScoped<ICocktailRepository<BLL.Entities.Cocktail>, BLL.Services.CocktailService>();
            builder.Services.AddScoped<ICocktailRepository<DAL.Entities.Cocktail>, DAL.Services.CocktailService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseCookiePolicy();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
