using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }


        public MusicDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);  // klucz główny
                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();  //pole z weryfikacją danych
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.NickName).HasMaxLength(20);
                e.ToTable("Musician");
            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);  // klucz główny
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();  //pole z weryfikacją danych
                
                e.ToTable("MusicLabel");
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);  // klucz główny
                e.Property(e => e.AlbumName).HasMaxLength(50).IsRequired();  //pole z weryfikacją danych
                e.Property(e => e.PublishDate).IsRequired();
                e.Property(e => e.IdMusicLabel).IsRequired();

                e.HasOne(e => e.MusicLabel)
                .WithMany(e => e.Album)
                .HasForeignKey(e => e.IdMusicLabel)
                .OnDelete(DeleteBehavior.Cascade);


                e.ToTable("Album");
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);  // klucz główny
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();  //pole z weryfikacją danych
                e.Property(e => e.Duration).IsRequired();
                e.Property(e => e.IdMusicAlbum);

                e.HasOne(e => e.Album)
                .WithMany(e => e.Track)
                .HasForeignKey(e => e.IdMusicAlbum)
                .OnDelete(DeleteBehavior.Cascade);


                e.ToTable("Track");
            });

            modelBuilder.Entity<Musician_Track>(e =>
            {
                e.HasKey(e => e.IdTrack);  // klucz główny
                e.HasKey(e => e.IdMusician);

                e.HasOne(e => e.Track)
                .WithMany(e => e.Musician_Track)
                .HasForeignKey(e => e.IdTrack)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(e => e.Musician)
                .WithMany(e => e.Musician_Track)
                .HasForeignKey(e => e.IdMusician)
                .OnDelete(DeleteBehavior.Cascade);


                e.ToTable("MusicLabel");
            });

            //end model create
        }
    }
}
