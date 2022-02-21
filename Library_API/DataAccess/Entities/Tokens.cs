using Library_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_API.DataAccess.Entities
{
    public class Tokens: EntityBase
    {
        public string Token { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ExpirationTime { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}