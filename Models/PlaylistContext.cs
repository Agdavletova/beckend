using Agdavletova_beckend.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.Extensions.DependencyModel;
using Microsoft.EntityFrameworkCore;


 namespace Agdavletova_beckend.Models
{
    public class PlaylistContext : DbContext
    {
        public PlaylistContext(DbContextOptions<PlaylistContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Playlist>().HasMany(playlist => playlist.song).WithMany();
        }

        public DbSet<Agdavletova_beckend.Models.Executor> Executor { get; set; }
        public DbSet<Agdavletova_beckend.Models.Song> Song { get; set; }
        public DbSet<Agdavletova_beckend.Models.Playlist> Playlist { get; set; } = default!;

        
    }
}