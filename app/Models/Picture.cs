using System;
using System.Collections.Generic;

#nullable disable

namespace app.Models
{
    public partial class Picture
    {
        public long IdPicture { get; set; }
        public string AlternativeText { get; set; }
        public long IdCategory { get; set; }
        public bool Published { get; set; }
        public string SourceHeader { get; set; }
        public string SourcePreview { get; set; }
        public string SourceOriginal { get; set; }
    }
}
