using Library_API.DataAccess;
using Library_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library_API.Controllers
{
    public class BaseController : ApiController
    {
        private readonly ILibraryService _service;
        private  IModelFactory _modelFactory;
        public BaseController(ILibraryService service)
        {
            _service = service;
        }
        protected IModelFactory ModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(Request);
                }
                return _modelFactory;
            }
        }

        protected ILibraryService LibraryService
        {
            get { return _service; }
        }

    }
}
