using Microsoft.EntityFrameworkCore;
using Orienteering.Domain.Entities;

namespace Orienteering.Infrastructure.Persistence
{
    class OrienteeringDbContext : DbContext
    {
        public OrienteeringDbContext(DbContextOptions<OrienteeringContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackPoint> TrackPoints { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .Property(t => t.Description)
                .HasMaxLength(200);


            modelBuilder.Entity<Track>()
                .Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Track>()
                .Property(t => t.Description)
                .HasMaxLength(200);


            modelBuilder.Entity<TrackPoint>()
                .Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<TrackPoint>()
                .Property(t => t.Description)
                .HasMaxLength(200);

            modelBuilder.Entity<TrackPoint>()
                .Property(t => t.Coordinates)
                .IsRequired();


            modelBuilder.Entity<User>()
                .Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(t => t.Surname)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(t => t.Email)
                .HasMaxLength(254)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(t => t.Password)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
