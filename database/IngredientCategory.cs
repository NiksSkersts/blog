using System.Collections.Generic;

#nullable disable

namespace database
{
    public partial class IngredientCategory
    {
        public IngredientCategory()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
