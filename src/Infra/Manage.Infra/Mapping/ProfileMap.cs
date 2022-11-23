using Manage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Infra.Mapping
{
    public class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            //builder.HasData(
            //    new Profile
            //    {
            //    }
            //);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);

            builder.HasOne(x => x.Users)
                .WithMany()
                .HasForeignKey(v => v.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
