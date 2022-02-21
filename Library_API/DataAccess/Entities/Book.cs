using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_API.Entities
{
    public class Book : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public int ColourId { get; set; }
        public virtual Colour Colour { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}