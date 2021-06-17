using System;
using System.Collections.Generic;

#nullable disable

namespace app.Models
{
    public partial class Category
    {
        public long IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
