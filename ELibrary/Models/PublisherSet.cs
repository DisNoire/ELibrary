using System;
using System.Collections.Generic;

namespace ELibrary.Models
{
    public partial class PublisherSet
    {
        public PublisherSet()
        {
            AuthorPublisher = new HashSet<AuthorPublisher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AuthorPublisher> AuthorPublisher { get; set; }
    }
}
