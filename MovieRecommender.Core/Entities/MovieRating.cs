using MovieRecommender.Core.SharedKernel;

namespace MovieRecommender.Core.Entities
{
    public class MovieRating : BaseEntity
    {
        public int UserId { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public double Rating { get; set; }
    }
}
