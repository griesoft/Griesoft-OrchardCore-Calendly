using Griesoft.OrchardCore.Calendly.Models;
using Griesoft.OrchardCore.Calendly.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

namespace Griesoft.OrchardCore.Calendly.Drivers
{
    /// <inheritdoc />
    public sealed class CalendlyPartDisplayDriver : ContentPartDisplayDriver<CalendlyPart>
    {
        /// <inheritdoc />
        public override IDisplayResult Display(CalendlyPart part, BuildPartDisplayContext context)
        {
            return Initialize<CalendlyPartViewModel>(nameof(CalendlyPart), viewmodel =>
            {
                viewmodel.Link = part.Link;
            })
            .Location("Content");
        }

        /// <inheritdoc />
        public override IDisplayResult Edit(CalendlyPart part, BuildPartEditorContext context)
        {
            return Initialize<CalendlyPartViewModel>($"{nameof(CalendlyPart)}_Edit", viewmodel =>
            {
                viewmodel.Link = part.Link;
            });
        }

        /// <inheritdoc />
        public override async Task<IDisplayResult> UpdateAsync(CalendlyPart part, UpdatePartEditorContext context)
        {
            var model = new CalendlyPartViewModel();

            await context.Updater.TryUpdateModelAsync(model, Prefix);

            part.Link = model.Link?.TrimStart('/');

            return Edit(part, context);
        }
    }
}