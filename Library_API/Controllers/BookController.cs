using Library_API.DataAccess;
using Library_API.Filters;
using Library_API.Models;
using Library_API.Models.Request;
using Library_API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library_API.Controllers
{
    public class BookController : BaseController
    {
        public BookController( ILibraryService LibraryService) : base(LibraryService)
        {

        }
        [CustomAuthorization]
        public IHttpActionResult Get()
        {
            try
            {
                var books = LibraryService.Books.Get();

                var model = new List<BookModelResp>();
                foreach (var item in books)
                {
                    var colour = LibraryService.Colours.Get(item.ColourId);
                    var author = LibraryService.Authors.Get(item.AuthorId);
                    model.Add(ModelFactory.Create(item, author, colour));
                }
                
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        [CustomAuthorization]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var book = LibraryService.Books.Get(id);
                var colour = LibraryService.Colours.Get(book.ColourId);
                var author = LibraryService.Authors.Get(book.AuthorId);

                if (book!= null && colour != null && author != null)
                {
                    var model = ModelFactory.Create(book, author, colour);
                    return Ok(model);
                }
                else
                {
                    return BadRequest("are not by that id");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        [ModelValidator]
        [CustomAuthorization]
        public IHttpActionResult Post([FromBody]BookModelReq bookmodel)
        {
            try
            {
                var entitybook = ModelFactory.Create(bookmodel);
                var book = LibraryService.Books.Insert(entitybook);
                var colour = LibraryService.Colours.Get(book.ColourId);
                var author = LibraryService.Authors.Get(book.AuthorId);
                var model = ModelFactory.Create(book,author,colour);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ModelValidator]
        [CustomAuthorization]

        public IHttpActionResult Put([FromBody] BookModelReq bookmodel)
        {
            try
            {
                var entitybook = ModelFactory.Create(bookmodel);
                var book = LibraryService.Books.Update(entitybook);
                var colour = LibraryService.Colours.Get(book.ColourId);
                var author = LibraryService.Authors.Get(book.AuthorId);
                var model = ModelFactory.Create(book, author, colour);
                return Ok(model);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [CustomAuthorization]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var bookfordelete = LibraryService.Books.Get(id);
                if (bookfordelete != null)
                {
                    LibraryService.Books.Delete(bookfordelete);
                    ILibraryService service = new LibraryService();
                }
                else
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
