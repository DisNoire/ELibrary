using System;
using System.Collections.Generic;

namespace ELibrary.Models
{
    public partial class AuthorPublisher
    {
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }

        public virtual AuthorSet Author { get; set; }
        public virtual PublisherSet Publisher { get; set; }
    }
}
