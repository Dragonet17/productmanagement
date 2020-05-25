using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ProductManagement.Areas.Identity.IdentityHostingStartup))]
namespace ProductManagement.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}