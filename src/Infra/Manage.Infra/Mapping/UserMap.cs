using Manage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUtilities.NetCore6.Seguranca;

namespace Manage.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasData(
            //    new User
            //    {
            //        UserName = "admin",
            //        Cpf = "11111111111",
            //        Email = "admin@gmail.com",                    
            //        Password = XAesCrip.Criptografar("admin"),
            //        CreatedAt = DateTime.Now,
            //        Active = true,
            //    }
            //);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.UserName)
               .HasColumnType("varchar(100)");
            builder.Property(f => f.Password)
                .HasColumnType("varchar(100)");
            builder.Property(f => f.Cpf)
                .IsRequired()
                .HasMaxLength(14);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.HasOne(f => f.Address)
                .WithMany()
                .HasForeignKey(v => v.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(d => d.Profiles)
            .WithOne(h => h.Users)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
