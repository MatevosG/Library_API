using Library_API.DataAccess.Entities;
using Library_API.Entities;
using Library_API.Repositories;

namespace Library_API.DataAccess
{
    public interface ILibraryService
    {
        Repository<Author> Authors { get; }
        Repository<Book> Books { get; }
        Repository<Colour> Colours { get; }
        Repository<User> Users { get; }
        Repository<Tokens> Tokens { get; }
        
    }
}
