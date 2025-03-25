using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Context;

namespace blog.Services
{
    public class BlogServices
    {
        private readonly DataContext _dataContext;

        public BlogServices(DataContext dataContext){
            _dataContext = dataContext;
        }
    }
}