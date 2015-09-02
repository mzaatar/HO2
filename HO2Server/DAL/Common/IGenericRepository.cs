﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HO2Server.DAL.Common
{
    public interface IGenericRepository<T> where T : class
    {
        IDbSet<T> DbSet
        {
            get; set;
        } 
        int ContextCount();

        IEnumerable<T> Get();
        T GetById(object id);

        IEnumerable<T> GetMany(Func<T, bool> where);

        IQueryable<T> GetManyQueryable(Func<T, bool> where);

        T Get(Func<T, Boolean> where);


        IQueryable<T> GetWithInclude(
            System.Linq.Expressions.Expression<Func<T,
                bool>> predicate, params string[] include);

        T GetSingle(Func<T, bool> predicate);
        T GetFirst(Func<T, bool> predicate);


        void Insert(T entityToInsert);

        void InsertMany(List<T> entitiesListToInsert);


        void Update(T entityToUpdate);

        bool Delete(object id);

        bool Delete(T entityToDelete);

        bool Delete(Func<T, Boolean> where);

        void Save();

        bool Exists(T entity);

    }
}