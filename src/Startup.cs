using Griesoft.OrchardCore.Calendly.Drivers;
using Griesoft.OrchardCore.Calendly.Migrations;
using Griesoft.OrchardCore.Calendly.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.ResourceManagement;

namespace Griesoft.OrchardCore.Calendly
{
    /// <inheritdoc />
    public class Startup : StartupBase
    {
        /// <inheritdoc />
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<CalendlyPart>()
                .UseDisplayDriver<CalendlyPartDisplayDriver>();

            services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();

            services.AddScoped<IDataMigration, RecipeMigration>();
        }
    }
}
