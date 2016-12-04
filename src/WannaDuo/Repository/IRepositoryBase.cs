
using System.Linq.Expressions;
using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace WannaDuo.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
         T GetByID(object id); 
         void Insert(T entity);	 		 
		 void Delete(object id);
         void Delete(T entityToDelete);
         void Update(T entityToUpdate);
         IQueryable<T> FindAll(Expression<Func<T, bool>> filter = null);
         IQueryable<T> FindAll(out int totalRows, Expression<Func<T, bool>> filter = null, int skip = 0, int take = 10);		  
         T FindOne(Expression<Func<T, bool>> filter);
         IQueryable<T> Fetch();        
         //DbContext InternalContext { get; }
        
    }
}