//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using HO2Server.DAL.Common;

//namespace HO2Server.Tests.DAL
//{
//    public class RepositoryTest<T> : IGenericRepository<T> where T : class
//    {
//        public void Delete(T entityToDelete)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(Func<T, bool> where)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(object id)
//        {
//            throw new NotImplementedException();
//        }

//        public bool Exists(object primaryKey)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<T> Get()
//        {
//            throw new NotImplementedException();
//        }

//        public T Get(Func<T, bool> where)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<T> GetAll()
//        {
//            throw new NotImplementedException();
//        }

//        public T GetById(object id)
//        {
//            throw new NotImplementedException();
//        }

//        public T GetFirst(Func<T, bool> predicate)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<T> GetMany(Func<T, bool> where)
//        {
//            throw new NotImplementedException();
//        }

//        public IQueryable<T> GetManyQueryable(Func<T, bool> where)
//        {
//            throw new NotImplementedException();
//        }

//        public T GetSingle(Func<T, bool> predicate)
//        {
//            throw new NotImplementedException();
//        }

//        public IQueryable<T> GetWithInclude(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params string[] include)
//        {
//            throw new NotImplementedException();
//        }

//        public void Insert(T entityToInsert)
//        {
//            throw new NotImplementedException();
//        }

//        public void Save()
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(T entityToUpdate)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
