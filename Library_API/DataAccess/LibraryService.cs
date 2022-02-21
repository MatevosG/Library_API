using Library_API.DataAccess.Entities;
using Library_API.Entities;
using Library_API.Repositories;

namespace Library_API.DataAccess
{
    public class LibraryService : ILibraryService
    {
        private Repository<Author> _authours;
        private Repository<Book> _books;
        private Repository<Colour> _colours;
        private Repository<User> _users;
        private Repository<Tokens> _tokens;
        private LibraryDbContext _context;
        
        public LibraryService()
        {
            _context = new LibraryDbContext();
        }
        public Repository<Author> Authors
        {
            get
            {
                if (_authours==null)
                {
                     _authours = new Repository<Author>(_context);
                }  
                return _authours;
            }
        }

        public Repository<Book> Books
        {
            get
            {
                if (_books==null)
                {
                    _books = new Repository<Book>(_context);
                }
                return _books;
            }
        }
        public Repository<Colour> Colours
        {
            get
            {
                if (_colours==null)
                {
                    _colours = new Repository<Colour>(_context);
                }
                return _colours;
            }
        }

        public Repository<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new Repository<User>(_context);
                }
                return _users;
            }
        }

        public Repository<Tokens> Tokens
        {
            get
            {
                if (_tokens == null)
                {
                    _tokens = new Repository<Tokens>(_context);
                }
                return _tokens;
            }
        }
    }
}