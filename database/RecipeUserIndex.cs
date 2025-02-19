﻿using System;

#nullable disable

namespace database
{
    public partial class RecipeUserIndex
    {
        public int IdRecipe { get; set; }
        public Guid IdUser { get; set; }

        public virtual Recipe IdRecipeNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
