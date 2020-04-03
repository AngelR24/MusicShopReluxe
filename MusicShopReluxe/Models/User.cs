using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopReluxe.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(25)]
        public string UserName { get; set; }

        [MaxLength(120)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<PlayList> PlayLists { get; set; }
        public IEnumerable<Genre> FavoriteGenres { get; set; }

    }
}
