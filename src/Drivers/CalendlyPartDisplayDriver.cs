using Griesoft.OrchardCore.Calendly.Models;
using Griesoft.OrchardCore.Calendly.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

namespace Griesoft.OrchardCore.Calendly.Drivers
{
    /// <inheritdoc />
    public class CalendlyPartDisplayDriver : ContentPartDisplayDriver<CalendlyPart>
    {
        /// <inheritdoc />
        public override IDisplayResult Display(CalendlyPart part)
        {
            return Initialize<CalendlyPartViewModel>(nameof(CalendlyPart), viewmodel =>
            {
                viewmodel.Link = part.Link;
            })
            .Location("Content");
        }
        /// <inheritdoc />
        public override IDisplayResult Edit(CalendlyPart part)
        {
            return Initialize<CalendlyPartViewModel>($"{nameof(CalendlyPart)}_Edit", viewmodel =>
            {
                viewmodel.Link = part.Link;
            });
        }
        /// <inheritdoc />
        public override async Task<IDisplayResult> UpdateAsync(CalendlyPart part, IUpdateModel updater)
        {
            var model = new CalendlyPartViewModel();

            await updater.TryUpdateModelAsync(model, Prefix);

            part.Link = model.Link?.TrimStart('/');

            return Edit(part);
        }
    }
}