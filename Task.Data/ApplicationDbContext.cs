﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TaskManage.Base.Entities;
using TaskManage.Entities;
using TaskManage.ViewModels;

namespace TaskManage.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("TaskContext"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ApplyGlobalFilters(builder);

            base.OnModelCreating(builder);


            //Assembly is just DLL
            //EF automatically scan all classes, that implement "IEntityTypeConfiguration" interface. and look for the fluent API in Configure() in all these class

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.Namespace == "TaskManage.Data.Config");
        }

        private static void ApplyGlobalFilters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskVM>();

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AduitChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            AduitChanges();
            return base.SaveChanges();
        }

        private void AduitChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity<Guid> entity)
                {
                    if (entity.IsDeleted == true)
                    {
                        entity.DeletedOn = DateTimeOffset.UtcNow;
                    }

                    else if (entry.State == EntityState.Added)
                    {
                        entity.CreatedOn = DateTimeOffset.UtcNow;
                    }

                    else if (entry.State == EntityState.Added)
                    {
                        entity.CreatedOn = DateTimeOffset.UtcNow;
                    }

                    else if (entry.State == EntityState.Modified)
                    {
                        entity.EditedOn = DateTimeOffset.UtcNow;
                    }
                }
                else if (entry.Entity is IUser record)
                {
                }
            }
        }


        public DbSet<TaskVM> Tasks { get; set; }
    }
}
