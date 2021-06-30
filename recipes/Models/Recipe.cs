using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            IngredientIndices = new HashSet<IngredientIndex>();
            TagIndices = new HashSet<TagIndex>();
            UserIndices = new HashSet<UserIndex>();
        }

        public int IdRecipe { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public TimeSpan CookingTime { get; set; }
        public int Servings { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual ICollection<IngredientIndex> IngredientIndices { get; set; }
        public virtual ICollection<TagIndex> TagIndices { get; set; }
        public virtual ICollection<UserIndex> UserIndices { get; set; }
    }
}
