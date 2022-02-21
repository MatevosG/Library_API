using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_API.Models.Request
{
    public class UserModelReq
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Password  { get; set; }
    }
}