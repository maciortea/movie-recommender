using MovieRecommender.Core.Entities;
using MovieRecommender.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommender.Infrastructure.Repositories
{
    public class MovieRatingRepository : EfRepository<MovieRating>, IMovieRatingRepository
    {
        public MovieRatingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
