using System;
using System.Collections.Generic;

#nullable disable

namespace database
{
    public partial class Recipe
    {
        public Recipe()
        {
            IngredientIndices = new HashSet<IngredientIndex>();
            RecipePictureIndices = new HashSet<RecipePictureIndex>();
            RecipeTagIndices = new HashSet<RecipeTagIndex>();
            RecipeUserIndices = new HashSet<RecipeUserIndex>();
        }

        public int IdRecipe { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public TimeSpan CookingTime { get; set; }
        public int Servings { get; set; }
        public DateTime Timestamp { get; set; }
        public string TotalOutcome { get; set; }

        public virtual ICollection<IngredientIndex> IngredientIndices { get; set; }
        public virtual ICollection<RecipePictureIndex> RecipePictureIndices { get; set; }
        public virtual ICollection<RecipeTagIndex> RecipeTagIndices { get; set; }
        public virtual ICollection<RecipeUserIndex> RecipeUserIndices { get; set; }
    }
}
