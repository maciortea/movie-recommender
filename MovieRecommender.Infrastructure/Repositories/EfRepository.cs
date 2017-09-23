using Microsoft.EntityFrameworkCore;
using MovieRecommender.Core.Interfaces;
using MovieRecommender.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRecommender.Infrastructure.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private bool disposed = false;

        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
