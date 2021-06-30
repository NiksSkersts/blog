using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            IngredientIndices = new HashSet<IngredientIndex>();
        }

        public int IdIngredient { get; set; }
        public string Name { get; set; }

        public virtual ICollection<IngredientIndex> IngredientIndices { get; set; }
    }
}
