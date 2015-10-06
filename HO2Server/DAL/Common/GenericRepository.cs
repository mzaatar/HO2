/* 
*   Code copied form http://www.codeproject.com/Articles/990492/RESTful-Day-sharp-Enterprise-Level-Application
*   Nice and generic Repo class
*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HO2Server.DAL.Common
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
           Db = new HO2Context("HO2Context.Web");
           DbSet = ((HO2Context)Db).Set<T>();
        }

        public GenericRepository(string connectionString)
        {
            Db = new HO2Context(connectionString);
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
            this.Save();
        }

        public virtual bool Delete(object id)
        {
            try
            {
                T entityToDelete = DbSet.Find(id);
                Delete(entityToDelete);
                this.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public virtual bool Delete(T entityToDelete)
        {
            if (Exists(entityToDelete))
            {
                DbSet.Remove(entityToDelete);
                this.Save();
                return true;
            }
            return false;
        }

        public virtual void Update(T entityToUpdate)
        {
            DbSet.Add(entityToUpdate);
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
            IQueryable<T> query = this.DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

     
        public bool Exists(T entity)
        {
            return DbSet.Contains(entity);
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
            Db.SaveChanges();
        }

        public void InsertMany(List<T> entitiesListToInsert)
        {
            foreach (var t in entitiesListToInsert)
            {
                DbSet.Add(t);
            }
            Db.SaveChanges();
        }

        public int ContextCount()
        {
            return DbSet.Count();
        }
    }
}