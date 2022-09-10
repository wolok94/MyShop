using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.InStock)
                .IsRequired();

            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.HasMany(x => x.ShoppingCarts)
                .WithMany(x => x.Products)
                .UsingEntity<ProductCart>(
                b => b.HasOne( b => b.ShoppingCart)
                .WithMany()
                .HasForeignKey(b => b.ShoppingCartId),

                 p => p.HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(b => b.ProductId),

                 bp =>
                 {
                     bp.HasKey(x => new { x.ProductId, x.ShoppingCartId});
                     bp.Property(x => x.DateOfCreated).HasDefaultValueSql("getutcdate()");
                 }
                );

        }
    }
}
