using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class IngredientRef
    {
        public IngredientRef()
        {
            IngredientIndices = new HashSet<IngredientIndex>();
        }

        public int IdRef { get; set; }
        public string Name { get; set; }

        public virtual ICollection<IngredientIndex> IngredientIndices { get; set; }
    }
}
