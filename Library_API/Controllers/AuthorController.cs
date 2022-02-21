using Library_API.DataAccess;
using Library_API.Filters;
using Library_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library_API.Controllers
{
    [CustomAuthorization]
    public class AuthorController : BaseController
    {
        public AuthorController(ILibraryService LibraryService) :base( LibraryService)
        {
            
        }
        
        public IHttpActionResult Get()
        {
            try
            {
                var authors = LibraryService.Authors.Get();
                var model = authors.Select(ModelFactory.Create);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        public IHttpActionResult Get(int id)
        {
            try
            {
                var author = LibraryService.Authors.Get(id);
                var model = ModelFactory.Create(author);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [ModelValidator]
        public IHttpActionResult Post([FromBody] AuthorModelReq authmodel)
        {
            try
            {
                var entityauthor = ModelFactory.Create(authmodel);
                var author = LibraryService.Authors.Insert(entityauthor);

                var model = ModelFactory.Create(author);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [ModelValidator]
        public IHttpActionResult Put([FromBody] AuthorModelReq authmodel)
        {
            try
            {
                var entityauthor = ModelFactory.Create(authmodel);
                var author = LibraryService.Authors.Update(entityauthor);

                var model = ModelFactory.Create(author);
                return Ok(model);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var authorfordelete = LibraryService.Authors.Get(id);
                if (authorfordelete != null)
                {
                    LibraryService.Authors.Delete(authorfordelete);
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
