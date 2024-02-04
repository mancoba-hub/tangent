using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Liso.Tangent
{
    public class FavouriteConfiguration : IEntityTypeConfiguration<Favourite>
    {
        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder.HasKey("Id").Metadata.IsPrimaryKey();
            builder.Property(x => x.HeroId);
            builder.Property(x => x.Name);
            builder.Property(x => x.DateCreated);
            builder.Property(x => x.Image);
            builder.Property(x => x.RawData);
        }
    }
}
