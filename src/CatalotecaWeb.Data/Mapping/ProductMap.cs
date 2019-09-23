using CatalotecaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalotecaWeb.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(60);
        }
    }
}
