using Library_API.DataAccess.Entities;
using Library_API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library_API.DataAccess
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext()
            : base("name=MyModels")
        {
        }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
    }
}