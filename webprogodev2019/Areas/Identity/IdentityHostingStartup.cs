using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webprogodev2019.Areas.Identity.Data;

[assembly: HostingStartup(typeof(webprogodev2019.Areas.Identity.IdentityHostingStartup))]
namespace webprogodev2019.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<webprogodev2019IdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebProgOdev2019Connection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<webprogodev2019IdentityDbContext>();
            });
        }
    }
}