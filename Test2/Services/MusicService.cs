using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Test2.DTOs;
using Test2.Models;

namespace Test2.Services
{
    public class MusicService : IMusicService
    {

        private MusicDbContext musicDbContext;

        public MusicService(MusicDbContext musicDbContext)
        {
            this.musicDbContext = musicDbContext;
        }

        public async Task DeleteMusician(int idMusician)
        {
            var musicianInfo = musicDbContext.Musicians.Where(e => e.IdMusician == idMusician).FirstOrDefault();

           

            if (musicianInfo is null)
            {
                throw new Exception("Nie istnieje");
            }

            var unreleasedTracks = musicDbContext.Tracks.Where(e => !e.IdMusicAlbum.HasValue).Select(e => e.IdTrack);

            var musiciansWithTracks = musicDbContext.Musician_Tracks.Where(e => unreleasedTracks.Contains(e.IdTrack)).Select(e => e.IdMusician);

            if (!musiciansWithTracks.Contains(idMusician))
            {
                throw new Exception("Nie można usunąć muzyka , już ma album");
            }
            // warunek

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    var MusicianTracks = musicDbContext.Musician_Tracks.Where(e => e.IdMusician == idMusician);
                    musicDbContext.Remove(MusicianTracks);

                    var Musician = musicDbContext.Musicians.Where(e => e.IdMusician == idMusician);

                    musicDbContext.Remove(Musician);

                    musicDbContext.SaveChangesAsync();

                    ///
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw new Exception("Błąd przy usuwaniu rekordów");
            }

           

        }

        public async Task<AlbumDto> GetAlbum(int idAlbum)
        {
            var albumInfo = musicDbContext.Albums.Where(e => e.IdAlbum == idAlbum).FirstOrDefault();

            if (albumInfo is null)
            {
                throw new Exception("Brak id");
            }


            return new AlbumDto
            {
                IdAlbum = idAlbum,
                IdMusicLabel = albumInfo.IdMusicLabel,
                AlbumName = albumInfo.AlbumName,
                PublishDate = albumInfo.PublishDate,
                Tracks = (List<TrackDto>)musicDbContext.Tracks.Where(e => e.IdMusicAlbum == idAlbum).OrderBy(e => e.Duration)


            };
            

            
            
        }

        
    }
}
