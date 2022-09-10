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

        }
    }
}
