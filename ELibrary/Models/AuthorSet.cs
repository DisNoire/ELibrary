using System;
using System.Collections.Generic;

namespace ELibrary.Models
{
    public partial class AuthorSet
    {
        public AuthorSet()
        {
            AuthorPublisher = new HashSet<AuthorPublisher>();
            BookSet = new HashSet<BookSet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AuthorPublisher> AuthorPublisher { get; set; }
        public virtual ICollection<BookSet> BookSet { get; set; }
    }
}
