using DIDataExample.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIDataExample.Repositories.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> SearchByFirstName(string name);
    }
}
