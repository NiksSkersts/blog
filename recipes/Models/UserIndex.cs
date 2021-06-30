using System;

#nullable disable

namespace server.Models
{
    public partial class UserIndex
    {
        public int IdRecipe { get; set; }
        public Guid IdUser { get; set; }

        public virtual Recipe IdRecipeNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
