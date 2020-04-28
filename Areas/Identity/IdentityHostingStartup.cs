using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nemesys.Areas.Identity.Data;

using Nemesys.Models;

[assembly: HostingStartup(typeof(Nemesys.Areas.Identity.IdentityHostingStartup))]
namespace Nemesys.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NemesysDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<NemesysDBContext>();
            });
        }
    }
}