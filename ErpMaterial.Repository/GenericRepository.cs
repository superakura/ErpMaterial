﻿using System;
using System.Collections.Generic;
//using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ErpMaterial.Models;
using Microsoft.EntityFrameworkCore;

namespace ErpMaterial.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ErpMaterialContext db;

        public GenericRepository(ErpMaterialContext _db)
        {
            db = _db;
        }

        public async Task<bool> Add(T Entity)
        {

            //老写法
            //db.Entry(Entity).State = EntityState.Added;
            await db.Set<T>().AddAsync(Entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(T Entity)
        {
            //老写法
            //db.Set<T>().Attach(Entity);
            //db.Entry(Entity).State = EntityState.Deleted;
            //新写法
            db.Set<T>().Remove(Entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(T Entity)
        {
            //老写法
            //db.Set<T>().Attach(Entity);
            //db.Entry(Entity).State = EntityState.Modified;
            //新写法
            db.Set<T>().Update(Entity);
            return await db.SaveChangesAsync() > 0;
        }
        private IEnumerable<T> CompileQuery(Expression<Func<T, bool>> exp)
        {
            var func = EF.CompileQuery((ErpMaterialContext context, Expression<Func<T, bool>> exps) => context.Set<T>().Where(exp));
            return func(db, exp);
        }
        public IEnumerable<T> GetEntities(Expression<Func<T, bool>> exp)
        {
            //var data = db.Set<T>().Find()
            return CompileQuery(exp);
        }

        public IEnumerable<T> GetEntitiesForPaging(int Page, int pageSize, Expression<Func<T, bool>> exp)
        {
            return CompileQuery(exp).Skip((Page - 1) * pageSize).Take(pageSize);
        }
        public T GetEntity(Expression<Func<T, bool>> exp)
        {
            return CompileQuerySingle(exp);
        }
        private T CompileQuerySingle(Expression<Func<T, bool>> exp)
        {
            var func = EF.CompileQuery((ErpMaterialContext context, Expression<Func<T, bool>> exps) => context.Set<T>().FirstOrDefault(exp));
            return func(db, exp);
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp);
        }
    }
}
