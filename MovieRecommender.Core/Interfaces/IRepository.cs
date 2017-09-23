using MovieRecommender.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace MovieRecommender.Core.Interfaces
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        T GetById(int id);

        List<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
