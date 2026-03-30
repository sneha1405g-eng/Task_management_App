using Microsoft.EntityFrameworkCore;
using TaskManagement.Api.Models;

namespace TaskManagement.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.ToTable("Tasks");

                entity.HasKey(t => t.Id);

                entity.Property(t => t.Title)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(t => t.Description)
                      .HasMaxLength(255);

                entity.Property(t => t.IsCompleted)
                      .HasDefaultValue(false);

                entity.Property<DateTime>("CreatedAt")
                      .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}