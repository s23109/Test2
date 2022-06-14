using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string? NickName { get; set; }

    }
}
