using MovieRecommender.Core.Dto;
using MovieRecommender.Core.Entities;
using MovieRecommender.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MovieRecommender.Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public List<MovieDto> Search(string query)
        {
            return
                _dbSet
                    .Where(m => m.Title.StartsWith(query) || m.Title.Contains(query))
                    .Select(m => new MovieDto
                    {
                        Id = m.Id,
                        Name = m.Title
                    })
                    .Take(10)
                    .ToList();
        }

        public Dictionary<int, string> GetMovieIdToTileDictionary(int[] movieIds)
        {
            return
                _dbSet
                    .Where(m => movieIds.Contains(m.Id))
                    .Select(m => new { m.Id, m.Title })
                    .ToDictionary(k => k.Id, v => v.Title);
        }
    }
}
