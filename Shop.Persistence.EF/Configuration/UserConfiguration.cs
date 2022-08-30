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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(a => a.Address)
                .WithOne(u => u.User)
                .HasForeignKey<User>(x => x.AddressId);



            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.NickName)
                .IsRequired();

            builder.Property(x => x.hashedPassword)
                .IsRequired();




        }
    }
}
