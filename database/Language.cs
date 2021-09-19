using System.Collections.Generic;

#nullable disable

namespace database
{
    public partial class Language
    {
        public Language()
        {
            Posts = new HashSet<Post>();
        }

        public int LanguageId { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
