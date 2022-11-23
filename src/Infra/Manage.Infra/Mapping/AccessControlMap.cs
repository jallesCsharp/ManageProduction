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
    public class AccessControlMap : IEntityTypeConfiguration<AccessControl>
    {
        public void Configure(EntityTypeBuilder<AccessControl> builder)
        {
            //builder.HasData(
            //        new AccessControl
            //        {
            //            DescriptionAccess = "Administrador",
            //            Visualize = true,
            //            Save = true,
            //            Alter = true,
            //            Edit = true,
            //            Delete = true,                        
            //            CreatedAt = DateTime.Now,
            //            Active = true,
            //        },
            //        new AccessControl
            //        {
            //            DescriptionAccess = "Visualizador",
            //            Visualize = true,
            //            Save = false,
            //            Alter = false,
            //            Edit = false,
            //            Delete = false,
            //            CreatedAt = DateTime.Now,
            //            Active = true,
            //        }
            //    );
        }
    }
}
