using Library_API.DataAccess;
using Library_API.Filters;
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
    public class UserController : BaseController
    {
        public UserController(ILibraryService LibraryService) : base(LibraryService)
        {

        }
        public IHttpActionResult Get()
        {
            try
            {
                var users = LibraryService.Users.Get();

                var model = new List<UserModelResp>();
                foreach (var item in users)
                {
                    model.Add(ModelFactory.Create(item));
                }

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
                var user = LibraryService.Users.Get(id);

                if (user!=null)
                {
                    var model = ModelFactory.Create(user);
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
        public IHttpActionResult Post([FromBody] UserModelReq usermodel)
        {
            try
            {
                var entityuser = ModelFactory.Create(usermodel);
                var user = LibraryService.Users.Insert(entityuser);
                var model = ModelFactory.Create(user);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [ModelValidator]
        public IHttpActionResult Put([FromBody] UserModelReq usermodel)
        {
            try
            {
                var entityuser = ModelFactory.Create(usermodel);
                var user = LibraryService.Users.Update(entityuser);
               
                var model = ModelFactory.Create(user);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
