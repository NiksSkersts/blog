using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Tag
    {
        public Tag()
        {
            RecipeTagIndices = new HashSet<RecipeTagIndex>();
        }

        public int IdTag { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RecipeTagIndex> RecipeTagIndices { get; set; }
    }
}
