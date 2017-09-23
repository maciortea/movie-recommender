using Microsoft.EntityFrameworkCore;
using MovieRecommender.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieRecommender.Infrastructure.EntityMappings
{
    public class MovieGenreMap : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(mg => new { mg.MovieId, mg.GenreId });

            builder.HasOne(mg => mg.Movie).WithMany(m => m.MovieGenres).HasForeignKey(mg => mg.MovieId);

            builder.HasOne(mg => mg.Genre).WithMany().HasForeignKey(mg => mg.GenreId);

            builder.Ignore(mg => mg.Id);
        }
    }
}
