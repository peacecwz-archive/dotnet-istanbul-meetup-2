using DIDataExample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DIDataExample.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ExampleDbContext Context { get; set; }
        DbSet<T> Table { get; set; }

        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        IEnumerable<T> Where(Expression<Func<T, bool>> where);
        IEnumerable<T> All();
        T GetById<TProperty>(TProperty id);
    }
}
