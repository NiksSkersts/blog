using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class RecipePictureIndex
    {
        public int IdRecipe { get; set; }
        public long IdPicture { get; set; }

        public virtual Picture IdPictureNavigation { get; set; }
        public virtual Recipe IdRecipeNavigation { get; set; }
    }
}
