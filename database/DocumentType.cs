﻿using System.Collections.Generic;

#nullable disable

namespace database
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }

        public long IdDocumentType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
