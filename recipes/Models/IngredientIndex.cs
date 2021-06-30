#nullable disable

namespace server.Models
{
    public partial class IngredientIndex
    {
        public int IdRecipe { get; set; }
        public int IdIngredient { get; set; }
        public double Grams { get; set; }

        public virtual Ingredient IdIngredientNavigation { get; set; }
        public virtual Recipe IdRecipeNavigation { get; set; }
    }
}
