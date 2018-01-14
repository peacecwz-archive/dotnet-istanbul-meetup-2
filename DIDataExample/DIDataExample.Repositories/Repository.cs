using DIDataExample.Entities;
using DIDataExample.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DIDataExample.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public ExampleDbContext Context { get; set; }
        public DbSet<T> Table { get; set; }
        public Repository(ExampleDbContext context)
        {
            this.Context = context;
            this.Table = this.Context.Set<T>();
        }

        public bool Add(T entity)
        {
            Table.Add(entity);
            return Save();
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return Save();
        }

        public bool Update(T entity)
        {
            Table.Attach(entity);
            Context.Entry<T>(entity).State = EntityState.Modified;
            return Save();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> where)
        {
            return Table.Where(where);
        }

        private bool Save()
        {
            try
            {
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T> All()
        {
            return Table;
        }

        public T GetById<TProperty>(TProperty id)
        {
            return Table.Find(id);
        }
    }
}
