using Microsoft.EntityFrameworkCore;
using MovieRecommender.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieRecommender.Infrastructure.EntityMappings
{
    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).HasColumnName("GenreId").ValueGeneratedNever();
        }
    }
}
