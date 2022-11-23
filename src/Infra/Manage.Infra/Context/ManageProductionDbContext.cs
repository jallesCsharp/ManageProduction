using Manage.Core.Interfaces.IBase;
using Manage.Core.Interfaces.IRepository.UnitOfWork;
using Manage.Core.Mediator.Interfaces;
using Manage.Core.Messages;
using Manage.Core.Models;
using Manage.Infra.Extensions;
using Manage.Infra.Mapping;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace Manage.Infra.Context
{
    public class ManageProductionDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public  ManageProductionDbContext(DbContextOptions<ManageProductionDbContext> options, IMediatorHandler mediatorHandler) : 
            base(options) 
        {
            _mediatorHandler = mediatorHandler;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<AccessControl> AccessControls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            base.OnModelCreating(modelBuilder);

            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IBaseModel).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }

            modelBuilder.ApplyConfiguration(new AccessControlMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());
        }

        public bool DatabaseExists()
        {
            try
            {
                return Database.GetService<IRelationalDatabaseCreator>().Exists();
            }
            catch (DbException)
            {
                return false;
            }
        }

        public async Task<bool> Commit()
        {
            if (await base.SaveChangesAsync() <= 0)
                return false;

            await _mediatorHandler.PublishEvents(this);

            return true;
        }
    }
}
