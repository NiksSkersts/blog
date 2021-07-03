using System;
using System.Collections.Generic;

#nullable disable

namespace database
{
    public partial class Document
    {
        public long IdDocument { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long IdDocumentType { get; set; }
        public bool Published { get; set; }
        public Guid IdUser { get; set; }

        public virtual DocumentType IdDocumentTypeNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
