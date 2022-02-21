using Library_API.DataAccess;
using Library_API.DataAccess.Entities;
using Library_API.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Library_API.Filters
{
    public class CustomAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!UserIsAuthorized(actionContext))
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,"Authorization Failure");

            base.OnActionExecuting(actionContext);
        }
       
        private bool UserIsAuthorized(HttpActionContext actionContext)
        {
            bool authorized = false;
            var tokenpair = actionContext.Request.Headers.FirstOrDefault(x => string.Equals(x.Key, HeaderNames.MyAuthorizationHeader));
            if (tokenpair.Value==null || tokenpair.Value.Count()==0)
                return authorized;
            var token = tokenpair.Value.FirstOrDefault();

            LibraryService service = new LibraryService();

             var mytoken = service.Tokens.Get().FirstOrDefault(x=>string.Equals(x.Token,token));
            if (mytoken != null && (mytoken.ExpirationTime - DateTime.UtcNow ).TotalHours>0)
                authorized = true;
            return authorized;
        }
    }
}