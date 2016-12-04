
using System.Linq.Expressions;
using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using WannaDuo.Model;

namespace WannaDuo.Repository
{
      public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        private Contexto context;
        private DbSet<T> dbSet;

        public RepositoryBase(Contexto context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            context.SaveChanges();
        }

        public virtual void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
        }


        public virtual IQueryable<T> FindAll(Expression<Func<T, bool>> filter = null)
        {
           
            var query = filter != null ? Fetch().Where(filter) : Fetch(); 

            return query;
        }

        public virtual IQueryable<T> FindAll(out int totalRows, Expression<Func<T, bool>> filter = null, int skip = 0, int take = 10)
        {
            IQueryable<T> query = FindAll(  filter );

            
            totalRows = query.Count();

            query = query.Skip(skip * take).Take(take);
  
            
            return query ;
        }


        public virtual T FindOne(Expression<Func<T, bool>> filter)
        {
           
            return Fetch().FirstOrDefault(filter);
        }

        public virtual IQueryable<T> Fetch()
        {
            IQueryable<T> query = dbSet;

            return query.AsQueryable();
        }

        //public DbContext InternalContext
        //{
        //    get { return this.context; }
        //}
    }
}