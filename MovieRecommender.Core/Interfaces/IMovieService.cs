using MovieRecommender.Core.Dto;
using System;
using System.Collections.Generic;

namespace MovieRecommender.Core.Interfaces
{
    public interface IMovieService : IDisposable
    {
        List<MovieRecommendationDto> GetRecommendedMovies(int[] preferredMovieIds);
    }
}
