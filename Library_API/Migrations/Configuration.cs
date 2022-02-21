namespace Library_API.Migrations
{
    using Library_API.DataAccess.Entities;
    using Library_API.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library_API.DataAccess.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Library_API.DataAccess.LibraryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //var colour = new Colour { Name = "karmir" };
            //var colour1 = new Colour { Name = "dexin" };
            //var colour2 = new Colour { Name = "sev" };
            //var colour3 = new Colour { Name = "spitak" };

            //var book1 = new Book { Colour = colour, Name = "tmbkaberdi arume" };
            //var book2 = new Book { Colour = colour1, Name = "sutlik vorskane" };
            //var book3 = new Book { Colour = colour2, Name = "Lilit" };
            //var book4 = new Book { Colour = colour3, Name = "chem hishum" };

            //var aftr = new Author { Name = "Hovhanes", SurName = "Tumanyan", Age = 154, Books = new List<Book> { book1, book2 } };
            //var aftr1 = new Author { Name = "Avetiq", SurName = "Isahakyan", Age = 120, Books = new List<Book> { book3, book4 } };

            //book1.Author = aftr;
            //book2.Author = aftr;
            //book3.Author = aftr1;
            //book4.Author = aftr1;

            //context.Colours.Add(colour);
            //context.Colours.Add(colour1);
            //context.Colours.Add(colour2);
            //context.Colours.Add(colour3);
            //context.Books.Add(book1);
            //context.Books.Add(book2);
            //context.Books.Add(book3);
            //context.Books.Add(book4);
            //context.Authors.Add(aftr);
            //context.Authors.Add(aftr1);

            //var user = new User {Id = 1, Name = "valod", Password = "vvvv" };
            //var token = new Tokens { Token = "aaaa", User = user, UserId = user.Id, CreationTime=DateTime.UtcNow , ExpirationTime=DateTime.UtcNow.AddHours(5)};
            //context.Users.Add(user);
            //context.Tokens.Add(token);
        }
    }
}
