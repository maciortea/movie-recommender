using Microsoft.EntityFrameworkCore;
using MovieRecommender.Core.Entities;
using MovieRecommender.Infrastructure.EntityMappings;

namespace MovieRecommender.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }

        public DbSet<MovieRating> MovieRatings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MovieMap());
            builder.ApplyConfiguration(new GenreMap());
            builder.ApplyConfiguration(new MovieGenreMap());
            builder.ApplyConfiguration(new MovieRatingMap());
        }
    }
}
