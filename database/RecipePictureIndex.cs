﻿#nullable disable

namespace database
{
    public partial class RecipePictureIndex
    {
        public int IdRecipe { get; set; }
        public long IdPicture { get; set; }

        public virtual Picture IdPictureNavigation { get; set; }
        public virtual Recipe IdRecipeNavigation { get; set; }
    }
}
