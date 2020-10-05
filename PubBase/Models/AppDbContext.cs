using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PubBase.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Pub> Pubs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pub>().HasData(
                new Pub { Id = 1, Name = "Svah", Address = "Liberec" },
                new Pub { Id = 2, Name = "Techtle", Address = "Jablonec nad Nisou" }
                );   
        }
    }
}
