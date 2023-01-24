using MeetingCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeetingInfrastructure
{
    public class GenericRepository<T> : IRepoGeneric<T> where T : class
    {
        protected readonly MeetingsContext Context;

        public GenericRepository(MeetingsContext context)
        {
            Context = context;
        }
        public T Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
            return entity;
            
        }
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public T Remove(T entity)
        {
            try
            {
                Context.Set<T>().Remove(entity);
                Context.SaveChanges();

            } catch(Exception ex)
            {
                return null;
            }
            return entity;
        }
    }
}
