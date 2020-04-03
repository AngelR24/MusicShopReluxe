using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopReluxe.Models
{
    public class PlayList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Song> SongsInPlaylist { get; set; }

        public IEnumerable<Genre> AssociatedGenres { get; set; }


        
    }
}
