using System;
using System.Collections.Generic;

#nullable disable

namespace app.Models
{
    public partial class Post
    {
        public long IdPost { get; set; }
        public long IdCat { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// HTML code
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Author. Author pic should be added to Author table.
        /// </summary>
        public long IdAuthor { get; set; }
        /// <summary>
        /// Mainly for Hero/Header picture
        /// </summary>
        public long IdPicture { get; set; }
        public DateOnly Date { get; set; }
        public bool Published { get; set; }
    }
}
