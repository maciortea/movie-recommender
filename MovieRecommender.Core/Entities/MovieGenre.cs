using MovieRecommender.Core.SharedKernel;

namespace MovieRecommender.Core.Entities
{
    public class MovieGenre : BaseEntity
    {
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
