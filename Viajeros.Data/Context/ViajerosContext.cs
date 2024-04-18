using Microsoft.EntityFrameworkCore;
using Viajeros.Data.Models;

namespace Viajeros.Data.Context
{
    public partial class ViajerosContext : DbContext
    {
        public ViajerosContext() { }
        public ViajerosContext(DbContextOptions<ViajerosContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=BENAME\\SQLEXPRESS;Initial Catalog=viajeros;Integrated Security=True; TrustServerCertificate=True;");
            }
        }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<VideoTag> VideoTags { get; set; }
        public virtual DbSet<PostImage> PostImages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
            .HasMany(n => n.Images);
            modelBuilder.Entity<Tag>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Video>()
             .HasMany(v => v.Tags);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
