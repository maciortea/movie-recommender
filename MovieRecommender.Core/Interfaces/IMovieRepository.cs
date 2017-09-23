using MovieRecommender.Core.Dto;
using MovieRecommender.Core.Entities;
using System.Collections.Generic;

namespace MovieRecommender.Core.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        List<MovieDto> Search(string query);

        Dictionary<int, string> GetMovieIdToTileDictionary(int[] movieIds);
    }
}
