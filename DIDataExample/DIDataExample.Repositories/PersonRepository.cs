using DIDataExample.Entities;
using DIDataExample.Entities.Tables;
using DIDataExample.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DIDataExample.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ExampleDbContext context) 
            : base(context)
        {
        }

        public IEnumerable<Person> SearchByFirstName(string name)
        {
            return Where(x => x.FirstName.StartsWith(name));
        }
    }
}
