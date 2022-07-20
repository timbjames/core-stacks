namespace SimpleConsole.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<BlogExtended> BlogExtended { get; set; }

        public string DbPath { get; }

        public BloggingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SA0273\SQLEXPRESS;Database=Blogging;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity
                .HasOne(x => x.BlogExtended)
                .WithOne(x => x.Blog)
                .HasForeignKey<BlogExtended>(x => x.BlogId)
                .IsRequired(false);
            });

            modelBuilder.Entity<BlogExtended>(entity =>
            {
                entity
                .HasOne(x => x.Blog)
                .WithOne(x => x.BlogExtended)
                .HasForeignKey<Blog>(x => x.BlogId)
                .IsRequired(false);
            });
        }
    }
}
