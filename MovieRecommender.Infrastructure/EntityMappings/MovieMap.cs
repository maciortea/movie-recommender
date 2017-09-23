using Microsoft.EntityFrameworkCore;
using MovieRecommender.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieRecommender.Infrastructure.EntityMappings
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnName("MovieId").ValueGeneratedNever();

            builder.Property(m => m.Title).HasMaxLength(200);
        }
    }
}
