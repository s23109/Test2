using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.DTOs
{
    public class AlbumDto
    {

        public int IdAlbum { get; set; }

        public string AlbumName { get; set; }

        public DateTime PublishDate { get; set; }

        public int IdMusicLabel { get; set; }

        public List<TrackDto> Tracks { get; set; }


    }
}

 
