using MusicStore2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore2.DataBaseManager
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("ConnectionString") { }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
    }
}