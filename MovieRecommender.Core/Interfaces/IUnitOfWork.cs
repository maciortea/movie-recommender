using System;

namespace MovieRecommender.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository MovieRepository { get; }

        IMovieRatingRepository MovieRatingRepository { get; }

        void Save();
    }
}
