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
    public class CompletedOrdersConfiguration : IEntityTypeConfiguration<CompletedOrder>
    {
        public void Configure(EntityTypeBuilder<CompletedOrder> builder)
        {
            builder.HasMany(x => x.Products)
                .WithMany(x => x.CompletedOrders)
                .UsingEntity<OrderProduct>(
                    o => o.HasOne(p => p.Product)
                    .WithMany()
                    .HasForeignKey(p => p.ProductId),

                    o => o.HasOne(o => o.Order)
                          .WithMany()
                          .HasForeignKey(o => o.OrderId),

                    op =>
                    {
                        op.HasKey(x => new { x.OrderId, x.ProductId });
                    }
                    );

            builder.HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId);



        }
    }
}
