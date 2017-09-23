using MovieRecommender.Core.SharedKernel;
using System.Collections.Generic;

namespace MovieRecommender.Core.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public IList<MovieGenre> MovieGenres { get; set; }

        public Movie()
        {
            MovieGenres = new List<MovieGenre>();
        }
    }
}
