using Library_API.DataAccess.Entities;
using Library_API.Entities;
using Library_API.Models.Request;
using Library_API.Models.Response;
using System.Net.Http;
using System.Web.Http.Routing;

namespace Library_API.Models
{
    public interface IModelFactory
    {
        AuthorModelResp Create(Author author);
        Author Create(AuthorModelReq authorModel);
        BookModelResp Create(Book book, Author author, Colour colour);
        Book Create(BookModelReq bookModel);
        Colour Create(ColourModelReq colour);
        ColourModelResp Create(Colour colour);
        UserModelResp Create(User user);
        User Create(UserModelReq usermodel);
    }

    public class ModelFactory : IModelFactory
    {
        private UrlHelper _urlHelper;
        public ModelFactory(HttpRequestMessage message)
        {
            _urlHelper = new UrlHelper(message);
        }

        public AuthorModelResp Create(Author author)
        {
            return new AuthorModelResp
            {
                Url = _urlHelper.Link("DefaultApi", new { id = author.Id }),
                Age = author != null ? author.Age : 0,
                Name = author != null ? author.Name : null,
                SurName = author != null ? author.SurName : null,
                AouthorId = author != null ? author.Id : 0,
            };
        }

        public Author Create(AuthorModelReq authorModel)
        {
            return new Author
            {
                Name = authorModel.Name != null ? authorModel.Name : null,
                SurName = authorModel.SurName != null ? authorModel.SurName : null,
                Age = authorModel != null ? authorModel.Age : 0,
                Id = authorModel.AouthorId,
            };
        }

        public Book Create(BookModelReq bookModel)
        {
            return new Book
            {
                Name = bookModel.BookName,
                AuthorId = bookModel.AuthorId,
                ColourId = bookModel.ColourId
            };
        }

        public Colour Create(ColourModelReq colour)
        {
            return new Colour
            {
                Id = colour != null ? colour.ColourId : 0,
                Name = colour != null ? colour.ColourName : null,
            };
        }

        public ColourModelResp Create(Colour colour)
        {
            return new ColourModelResp
            {
                ColourId = colour != null ? colour.Id : 0,
                ColourName = colour != null ? colour.Name : null,
            };
        }
        public BookModelResp Create(Book book, Author author, Colour colour)
         {
            return new BookModelResp
            {
                AuthorName = author.Name,
                BookId = book.Id,
                BookName = book.Name,
                ColourName = colour.Name,
            };
        }

        public UserModelResp Create(User user)
        {
            return new UserModelResp
            {
                UserId=user.Id,
                Name = user.Name,
            };
        }

        public User Create(UserModelReq usermodel)
        {
            return new User
            {
                Id = usermodel.Id,
                Name = usermodel.Name,
                Password = usermodel.Password
            };
        }
    }
}
