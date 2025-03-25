using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<UserModel> User {get; set;}
        public DbSet<BlogModel> Blog {get; set;}
    }
}