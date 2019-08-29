using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace Statistics.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");

            /* todo: there's a bug currently in mono which returns data in utc all the time despite
            even forcing ToLocalTime. This package fixing than. Since this will be resolved 
            on mono level this package would go away. https://github.com/jsakamoto/Toolbelt.Blazor.TimeZoneKit
            */
            app.UseLocalTimeZone();
        }
    }
}
