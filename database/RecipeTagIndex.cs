#nullable disable

namespace database
{
    public partial class RecipeTagIndex
    {
        public int IdRecipe { get; set; }
        public int IdTag { get; set; }

        public virtual Recipe IdRecipeNavigation { get; set; }
        public virtual Tag IdTagNavigation { get; set; }
    }
}
