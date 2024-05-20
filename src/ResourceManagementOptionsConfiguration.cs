using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace Griesoft.OrchardCore.Calendly
{
    /// <inheritdoc />
    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ResourceManagementOptionsConfiguration()
        {
            _manifest = new ResourceManifest();

            _manifest
                .DefineScript("calendly")
                .SetUrl("https://assets.calendly.com/assets/external/widget.js");
        }

        /// <inheritdoc />
        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}
