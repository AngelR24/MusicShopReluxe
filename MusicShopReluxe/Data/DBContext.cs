using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicShopReluxe.Models;

namespace MusicShopReluxe.Data
{
    public class DBContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DBContext(
            DbContextOptions<DBContext> options) : base(options)
        {
        }
    }
}
