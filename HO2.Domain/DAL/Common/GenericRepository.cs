/* 
*   Code copied form http://www.codeproject.com/Articles/990492/RESTful-Day-sharp-Enterprise-Level-Application
*   Nice and generic Repo class
*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Contexts;

namespace HO2.Domain.DAL.Common
{
    /// <summary>
    /// Generic Repository class for Entity Operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal HO2Context Db;
        public IDbSet<T> DbSet { get; set; }

        public GenericRepository()
        {
            Db = new HO2Context();
            DbSet = Db.Set<T>();
        }

        public GenericRepository(HO2Context context)
        {
           Db = context;
           DbSet = ((HO2Context)Db).Set<T>();
        }
        
        public virtual IEnumerable<T> Get()
        {
            IQueryable<T> query = DbSet;
            return query.ToList();
        }

      
        public virtual T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(T entityToInsert)
        {
            DbSet.Add(entityToInsert);
            Save();
        }

        public virtual T Delete(object id)
        {
            T entityToDelete = DbSet.Find(id);
            return Delete(entityToDelete);
        }

        public virtual T Delete(T entityToDelete)
        {
            if (Db.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            var item = DbSet.Remove(entityToDelete);
            Save();
            return item;
        }

        public virtual void Update(T entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Db.Entry(entityToUpdate).State = EntityState.Modified;
            Save();
        }

      
        public virtual IEnumerable<T> GetMany(Func<T, bool> where)
        {
            return DbSet.Where(where).ToList();
        }

       
        public virtual IQueryable<T> GetManyQueryable(Func<T, bool> where)
        {
            return DbSet.Where(where).AsQueryable();
        }

      
        public T Get(Func<T, Boolean> where)
        {
            return DbSet.Where(where).FirstOrDefault<T>();
        }

     
        public bool Delete(Func<T, Boolean> where)
        {
            try
            {
                IQueryable<T> objects = DbSet.Where<T>(where).AsQueryable();
                foreach (T obj in objects)
                    DbSet.Remove(obj);
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<T> GetWithInclude(
            System.Linq.Expressions.Expression<Func<T,
                bool>> predicate, params string[] include)
        {
            IQueryable<T> query = DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

     
        public bool Exists(object primaryKey)
        {
            return DbSet.Find(primaryKey) != null;
        }
        
        public T GetSingle(Func<T, bool> predicate)
        {
            return DbSet.Single<T>(predicate);
        }

    
        public T GetFirst(Func<T, bool> predicate)
        {
            return DbSet.First<T>(predicate);
        }


        public void Save()
        {
            Db.Save();
        }

        public void InsertMany(List<T> entitiesListToInsert)
        {
            foreach (var t in entitiesListToInsert)
            {
                DbSet.Add(t);
            }
            Db.Save();
        }

        public int ContextCount()
        {
            return DbSet.Count();
        }
    }
}