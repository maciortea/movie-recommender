using Microsoft.EntityFrameworkCore;
using MovieRecommender.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieRecommender.Infrastructure.EntityMappings
{
    public class MovieRatingMap : IEntityTypeConfiguration<MovieRating>
    {
        public void Configure(EntityTypeBuilder<MovieRating> builder)
        {
            builder.HasKey(mr => new { mr.UserId, mr.MovieId });

            builder.HasOne(mr => mr.Movie).WithMany().HasForeignKey(mr => mr.MovieId);

            builder.Ignore(mg => mg.Id);
        }
    }
}
