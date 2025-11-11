using Microsoft.EntityFrameworkCore;
using BooksApp.Models;

namespace BooksApp.Data
{
    public class BooksContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TitleTag> TitlesTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "data", "books.db");
            optionsBuilder.UseSqlite($"Data Source={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nombre plural para TitleTag
            modelBuilder.Entity<TitleTag>().ToTable("TitlesTags");

            // Orden de columnas en Title
            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.TitleId).HasColumnOrder(0);
                entity.Property(e => e.AuthorId).HasColumnOrder(1);
                entity.Property(e => e.TitleName).HasColumnOrder(2);
            });
        }
    }
}
