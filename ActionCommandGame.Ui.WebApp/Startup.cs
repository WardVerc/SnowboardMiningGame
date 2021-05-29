using ActionCommandGame.Repository;
using ActionCommandGame.Services;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ActionCommandGame.Ui.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //add appsettings
            var appSettings = new AppSettings();
            Configuration.Bind(nameof(AppSettings), appSettings);

            services.AddSingleton(appSettings);
            
            //add database context
            services.AddDbContext<ActionButtonGameDbContext>(config =>
            {
                //getconnectionstring + dbcontext file is in other project so define where startup project is
                config.UseSqlServer(Configuration.GetConnectionString("Default"), 
                    b => b.MigrationsAssembly("ActionCommandGame.Ui.WebApp"));
            });
            
            //Identity to create users -> register and logging in
            //also add Roles, for Admin users etc.
            services.AddDefaultIdentity<IdentityUser>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequiredLength = 4;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ActionButtonGameDbContext>()
                .AddDefaultTokenProviders();

            //Cookie for logging in
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Identity.Cookie";
                config.LoginPath = "/Home/Login";
            });

            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IPositiveGameEventService, PositiveGameEventService>();
            services.AddTransient<INegativeGameEventService, NegativeGameEventService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IPlayerItemService, PlayerItemService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //check first if user is logged in as an existing user
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}