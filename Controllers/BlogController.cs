using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogServices _blogServices;

        public BlogController(BlogServices blogServices)
        {
            _blogServices = blogServices;
        }
    }
}