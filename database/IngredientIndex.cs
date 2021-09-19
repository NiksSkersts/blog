#nullable disable

namespace database
{
    public partial class IngredientIndex
    {
        public int IdRecipe { get; set; }
        public int IdIngredient { get; set; }
        public double Grams { get; set; }
        public int IdRef { get; set; }

        public virtual Ingredient IdIngredientNavigation { get; set; }
        public virtual Recipe IdRecipeNavigation { get; set; }
        public virtual IngredientRef IdRefNavigation { get; set; }
    }
}
