using Base.Infrastructure.Mocks;
using BaseLibrary.Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Base.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Todo> Todos => Set<Todo>();

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HandleMocks();

            ApplyGlobalQueryFilters(modelBuilder);

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<ValidationResult>();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.Cascade;
        }

        private void ApplyGlobalQueryFilters(ModelBuilder builder)
        {
            builder.Entity<Todo>().HasQueryFilter(t => !t.Deleted);
        }
    }
}
