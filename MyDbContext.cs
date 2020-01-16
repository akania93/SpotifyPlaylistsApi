using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpotifyPlaylistsApi.Models;

namespace SpotifyPlaylistsApi
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = SpotifyPlaylists.db;");
        }

        public DbSet<PlaylistCategories> PlaylistCategories { get; set; }
        public DbSet<Playlists> Playlists { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        public DbSet<Artists> Artists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Playlists>()
            //    .HasMany(i => i.Tracks)
            //    .WithOne(c => c.Playlist)
            //    .HasForeignKey(p => p.PlaylistRefId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Tracks>()
            //    .HasMany(i => i.Artists)
            //    .WithOne(c => c.Track)
            //    .HasForeignKey(p => p.TrackRefId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlaylistCategories>().HasData(
                new PlaylistCategories() { Id = 1, Value = "Blues" },
                new PlaylistCategories() { Id = 2, Value = "Country" },
                new PlaylistCategories() { Id = 3, Value = "Disco polo", },
                new PlaylistCategories() { Id = 4, Value = "Elektroniczna" },
                new PlaylistCategories() { Id = 5, Value = "Folk" },
                new PlaylistCategories() { Id = 6, Value = "Filmowa" },
                new PlaylistCategories() { Id = 7, Value = "Hip-hop" },
                new PlaylistCategories() { Id = 8, Value = "Jazz" },
                new PlaylistCategories() { Id = 9, Value = "Metal" },
                new PlaylistCategories() { Id = 10, Value = "Pop" },
                new PlaylistCategories() { Id = 11, Value = "Poważna" },
                new PlaylistCategories() { Id = 12, Value = "Reggae" },
                new PlaylistCategories() { Id = 13, Value = "Rock" },
                new PlaylistCategories() { Id = 14, Value = "Inne" }
            );
        }
    }
}
