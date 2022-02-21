using Library_API.DataAccess;
using Library_API.DataAccess.Entities;
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
    public class AuthorizationController : BaseController
    {
        public AuthorizationController(ILibraryService LibraryService) : base(LibraryService)
        {

        }
        [HttpPost]
        [ModelValidator]
        public IHttpActionResult Login([FromBody] LoginModelReq loginModel)
        {

            var user = LibraryService.Users.Get().FirstOrDefault(x => string.Equals(x.Name, loginModel.UserName) && string.Equals(x.Password, loginModel.Password));
            if (user == null)
                return NotFound();
            var token = LibraryService.Tokens.Insert(new Tokens
            {
                CreationTime = DateTime.UtcNow,
                ExpirationTime = DateTime.UtcNow.AddHours(5),
                UserId = user.Id,
                Token = Guid.NewGuid().ToString()
            });
            if (token == null)
                return NotFound();

            return Ok(new LoginModelResp { Token=token.Token});
        }
    }
}
