using System.Collections.Generic;

#nullable disable

namespace database
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            IngredientIndices = new HashSet<IngredientIndex>();
        }

        public int IdIngredient { get; set; }
        public string Name { get; set; }
        public int? IdCategory { get; set; }

        public virtual IngredientCategory IdCategoryNavigation { get; set; }
        public virtual ICollection<IngredientIndex> IngredientIndices { get; set; }
    }
}
