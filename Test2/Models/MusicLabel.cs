using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class MusicLabel
    {

        public int IdMusicLabel { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual IEnumerable<Album> Album { get; set; }

    }
}
