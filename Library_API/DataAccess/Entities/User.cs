using Library_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_API.DataAccess.Entities
{
    public class User: EntityBase
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}