using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Tag
    {
        public Tag()
        {
            TagIndices = new HashSet<TagIndex>();
        }

        public int IdTag { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TagIndex> TagIndices { get; set; }
    }
}
