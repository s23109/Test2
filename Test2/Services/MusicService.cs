using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AlbumDto GetAlbum(int idAlbum)
        {
            var albumInfo = musicDbContext.Albums.Where(e => e.IdAlbum == idAlbum).FirstOrDefault();

            AlbumDto albumDto = new AlbumDto
            {
                IdAlbum = idAlbum,
                IdMusicLabel = albumInfo.IdMusicLabel,
                AlbumName = albumInfo.AlbumName,
                PublishDate = albumInfo.PublishDate,
                Tracks = (List<TrackDto>)musicDbContext.Tracks.Where(e => e.IdMusicAlbum == idAlbum)


            };
            return  albumDto;

            
            
        }
    }
}
