using OrchardCore.Data.Migration;
using OrchardCore.Recipes.Services;

namespace Griesoft.OrchardCore.Calendly.Migrations
{
    /// <inheritdoc />
    public class RecipeMigration(IRecipeMigrator recipeMigrator) : DataMigration
    {
        private const int MigrationVersionCount = 1;

        private readonly IRecipeMigrator _recipeMigrator = recipeMigrator;

        /// <summary>
        ///
        /// </summary>
        public async Task<int> CreateAsync()
        {
            await _recipeMigrator.ExecuteAsync("calendly.recipe.json", this);

            return MigrationVersionCount;
        }
    }
}
