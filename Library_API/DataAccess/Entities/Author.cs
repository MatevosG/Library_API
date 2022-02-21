using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_API.Entities
{
    public class Author : EntityBase
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}