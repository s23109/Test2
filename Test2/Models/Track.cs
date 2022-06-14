using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        [MaxLength(20)]
        public string TrackName { get; set; }

        public float Duration { get; set; }

        public int? IdMusicAlbum { get; set; }

        public virtual IEnumerable<Musician_Track> Musician_Track { get; set; }

        public virtual Album Album { get; set; }

    }
}
