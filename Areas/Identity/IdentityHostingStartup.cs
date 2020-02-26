using System;
using FlightManager.Areas.Identity.Data;
using FlightManager.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FlightManager.Areas.Identity.IdentityHostingStartup))]
namespace FlightManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FlightManagerDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FlightManagerDBContextConnection")));

                services.AddDefaultIdentity<FlightManagerUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<FlightManagerDBContext>()
                    .AddDefaultTokenProviders();
            });
        }
    }
}