using System;

namespace raftypoile.Models.Main
{
    public partial class Document
    {
        public long IdDocument { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long IdDocumentType { get; set; }
        /// <summary>
        /// Pieejams publiski?
        /// </summary>
        public bool Published { get; set; }
        /// <summary>
        /// Dokumenta ievietotājs,. autors u.t.t
        /// </summary>
        public Guid IdUser { get; set; }

        public virtual DocumentType IdDocumentTypeNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
