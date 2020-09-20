using System;
using System.Collections.Generic;

namespace ELibrary.Models
{
    public partial class BookSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }

        public virtual AuthorSet Author { get; set; }
    }
}
