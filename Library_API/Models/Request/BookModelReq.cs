using Library_API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_API.Models.Request
{
    public class BookModelReq
    {
        [Required]
        public string BookName { get; set; }
      
        public int AuthorId { get; set;}
        
        public int ColourId { get; set; }
    }
}