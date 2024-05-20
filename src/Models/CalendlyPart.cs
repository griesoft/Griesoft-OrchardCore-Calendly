using OrchardCore.ContentManagement;

namespace Griesoft.OrchardCore.Calendly.Models
{
    /// <summary>
    /// A content part for embedding Calendly on a website.
    /// </summary>
    public class CalendlyPart : ContentPart
    {
        /// <summary>
        /// The relative link to the users Calendly profile.
        /// </summary>
        public string? Link { get; set; }
    }
}
