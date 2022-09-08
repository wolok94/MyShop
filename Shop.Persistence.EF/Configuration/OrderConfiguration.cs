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
    public class OrderConfiguration : IEntityTypeConfiguration<OrderToSend>
    {
        public void Configure(EntityTypeBuilder<OrderToSend> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.BasketId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.Shipment)
                .IsRequired();

            builder.HasOne(b => b.Basket);
                
                
                
        }
    }
}
