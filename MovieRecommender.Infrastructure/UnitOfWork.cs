using MovieRecommender.Core.Interfaces;
using MovieRecommender.Infrastructure.Repositories;
using System;

namespace MovieRecommender.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly AppDbContext _dbContext;
        private IMovieRepository _movieRepository;
        private IMovieRatingRepository _movieRatingRepository;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IMovieRepository MovieRepository
        {
            get { return _movieRepository ?? (_movieRepository = new MovieRepository(_dbContext)); }
        }

        public IMovieRatingRepository MovieRatingRepository
        {
            get { return _movieRatingRepository ?? (_movieRatingRepository = new MovieRatingRepository(_dbContext)); }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #region IDisposable implementation

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

        #endregion
    }
}
