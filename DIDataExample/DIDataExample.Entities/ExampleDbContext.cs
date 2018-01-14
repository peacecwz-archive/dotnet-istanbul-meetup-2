using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIDataExample.Entities
{
    public class ExampleDbContext : DbContext
    {
        public  ExampleDbContext(DbContextOptions<ExampleDbContext> options)
            : base(options)
        {

        }

        public DbSet<Tables.Person> Persons { get; set; }
    }
}
