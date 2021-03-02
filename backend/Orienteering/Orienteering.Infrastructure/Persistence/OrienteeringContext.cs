using Microsoft.EntityFrameworkCore;
using Orienteering.Domain.Entities;

namespace Orienteering.Infrastructure.Persistence
{
    public class OrienteeringContext : DbContext
    {
        public OrienteeringContext(DbContextOptions<OrienteeringContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackPoint> TrackPoints { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>(
                ob =>
                {
                    ob.Property(t => t.Name)
                        .HasMaxLength(50)
                        .IsRequired();

                    ob.Property(t => t.Description)
                        .HasMaxLength(200);
                });

            modelBuilder.Entity<Track>(
                ob =>
                {
                    ob.Property(t => t.Name)
                        .HasMaxLength(50)
                        .IsRequired();

                    ob.Property(t => t.Description)
                        .HasMaxLength(200);
                });

            modelBuilder.Entity<TrackPoint>(
                ob =>
                {
                    ob.Property(t => t.Name)
                        .HasMaxLength(50)
                        .IsRequired();

                    ob.Property(t => t.Description)
                        .HasMaxLength(200);

                    ob.OwnsOne(
                    t => t.Coordinates,
                    sa =>
                    {
                        sa.Property(p => p.Latitude).IsRequired();
                        sa.Property(p => p.Longitude).IsRequired();
                    });
                });

            modelBuilder.Entity<User>(
                ob =>
                {
                    ob.Property(t => t.Name)
                        .HasMaxLength(50)
                        .IsRequired();

                    ob.Property(t => t.Surname)
                        .HasMaxLength(50)
                        .IsRequired();

                    ob.Property(t => t.Email)
                        .HasMaxLength(254)
                        .IsRequired();

                    ob.Property(t => t.Password)
                        .HasMaxLength(50)
                        .IsRequired();

                    ob.HasMany(t => t.GamesCreated)
                        .WithOne(t => t.Creator);
                });
        }
    }
}
