using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class RecipeUserIndex
    {
        public int IdRecipe { get; set; }
        public Guid IdUser { get; set; }

        public virtual Recipe IdRecipeNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
