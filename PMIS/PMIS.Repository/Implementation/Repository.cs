﻿using Microsoft.EntityFrameworkCore;
using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repository.Implementation
{
    public class Repository<TEntity>
       : IRepository<TEntity>
       where TEntity : class
    {
        protected PMISDbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public Repository(PMISDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
             _dbSet.AddAsync(entity);
        }
        public virtual void AddRange(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Remove(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(Expression<Func<TEntity, bool>> filter)
        {
            _dbSet.RemoveRange(_dbSet.Where(filter));
        }

        public virtual void Edit(TEntity entityToUpdate)
        {
            if (_dbContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
            }
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            var count = 0;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            count = query.Count();
            return count;
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public virtual IQueryable<TEntity> Get()
        {
            return _dbSet;
        }
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).AsQueryable();
        }
        public virtual async Task<TEntity?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual (IList<TEntity> data, int total, int totalDisplay) Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            IQueryable<TEntity> query = _dbSet;
            var total = query.Count();
            var totalDisplay = total;

            if (filter != null)
            {
                query = query.Where(filter);
                totalDisplay = query.Count();
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                var result = orderBy(query).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                if (isTrackingOff)
                    return (result.AsNoTracking().ToList(), total, totalDisplay);
                else
                    return (result.ToList(), total, totalDisplay);
            }
            else
            {
                var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                if (isTrackingOff)
                    return (result.AsNoTracking().ToList(), total, totalDisplay);
                else
                    return (result.ToList(), total, totalDisplay);
            }
        }

        //public virtual (IList<TEntity> data, int total, int totalDisplay) GetDynamic(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    string orderBy = null,
        //    string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        //{
        //    IQueryable<TEntity> query = _dbSet;
        //    var total = query.Count();
        //    var totalDisplay = query.Count();

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //        totalDisplay = query.Count();
        //    }

        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        var result = query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //        if (isTrackingOff)
        //            return (result.AsNoTracking().ToList(), total, totalDisplay);
        //        else
        //            return (result.ToList(), total, totalDisplay);
        //    }
        //    else
        //    {
        //        var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //        if (isTrackingOff)
        //            return (result.AsNoTracking().ToList(), total, totalDisplay);
        //        else
        //            return (result.ToList(), total, totalDisplay);
        //    }
        //}

        public virtual async Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", bool isTrackingOff = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                var result = orderBy(query);

                if (isTrackingOff)
                    return await result.AsNoTracking().ToListAsync();
                else
                    return await result.ToListAsync();
            }
            else
            {
                if (isTrackingOff)
                    return await query.AsNoTracking().ToListAsync();
                else
                    return await query.ToListAsync();
            }
        }


        //Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties, bool isTrackingOff)
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter = null,
        //    string orderBy = null,
        //    string includeProperties = "", bool isTrackingOff = false)
        //{
        //    IQueryable<TEntity> query = _dbSet;

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        var result = query.OrderBy(orderBy);

        //        if (isTrackingOff)
        //            return result.AsNoTracking().ToList();
        //        else
        //            return result.ToList();
        //    }
        //    else
        //    {
        //        if (isTrackingOff)
        //            return query.AsNoTracking().ToList();
        //        else
        //            return query.ToList();
        //    }
        //}
    }
}
