using Microsoft.EntityFrameworkCore;
using MovieReviewsDL;
using MovieReviewsBL;
using Microsoft.AspNetCore.Identity;

namespace WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDefaultIdentity<IdentityUser>()
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<MyContext>()
                            .AddDefaultTokenProviders();


            builder.Services.AddAutoMapper(typeof(MapperConfig));


            builder.Services.AddDbContext<MyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<FilmManager>();

            builder.Services.AddScoped<ReviewManager>();

            builder.Services.AddScoped<UserManager>();

            builder.Services.AddScoped<MovieReviewsBL.UserManager>();

            builder.Services.AddScoped(typeof(BaseManager<,,>));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }


                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }

                var adminUser = await userManager.FindByEmailAsync("ramazan427@gmail.com");
                if (adminUser == null)
                {
                    var newAdmin = new IdentityUser
                    {
                        UserName = "admin@example.com",
                        Email = "admin@example.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdmin, "AdminPassword123!");
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
