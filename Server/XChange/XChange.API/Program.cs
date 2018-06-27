using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using XChange.Domain;

namespace XChange.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreatedWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<XChangeContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    Initialize(context, userManager, roleManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static IWebHost CreatedWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static async Task Initialize(XChangeContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.CurrencyRates.Any() || context.Users.Any())
            {
                return;   // DB has been seeded
            }

            string role = "Admin";
            string email = "smashraid@gmail.com";
            await roleManager.CreateAsync(new IdentityRole(role));
            await userManager.CreateAsync(new ApplicationUser
            {
                UserName = email,
                FirstName = "Saulo",
                LastName = "Tsuchida",
                Email = email,
                LockoutEnabled = false
            });
            var user = await userManager.FindByEmailAsync(email);
            await userManager.AddPasswordAsync(user, "P@$$123");
            await userManager.AddToRoleAsync(user, role);

            context.CurrencyRates.Add(
                new CurrencyRate
                {
                    From = "USD",
                    To = "EUR",
                    Rate = 0.2566M,
                    Log = DateTime.Now.AddDays(-3)
                });

            context.SaveChanges();
        }
    }
}
