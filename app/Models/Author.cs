using System;
using System.Collections.Generic;

#nullable disable

namespace app.Models
{
    public partial class Author
    {
        public long IdAuthor { get; set; }
        public string Name { get; set; }
        public long IdEmail { get; set; }
        /// <summary>
        /// Author Pic
        /// </summary>
        public long IdPicture { get; set; }
        public long IdDocument { get; set; }
    }
}
