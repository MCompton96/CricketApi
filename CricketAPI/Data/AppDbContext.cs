using CricketAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<GameLocation> GmeLocations { get; set; }
        public DbSet<Batting> Battings { get; set; }
        public DbSet<Bowling> Bowlings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Fielding> FieldingStats { get; set; }
        public DbSet<Wicket> Wickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Game>()
                .HasOne(x => x.Result)
                .WithOne(x => x.Game)
                .HasForeignKey<Result>(x => x.GameId);

            modelBuilder
                .Entity<Game>()
                .HasOne(x => x.Location)
                .WithOne(x => x.Game)
                .HasForeignKey<GameLocation>(x => x.GameId);

            modelBuilder
                .Entity<Game>()
                .HasOne(x => x.Batting)
                .WithOne(x => x.Game)
                .HasForeignKey<Batting>(x => x.GameId);

            modelBuilder
                .Entity<Game>()
                .HasOne(x => x.Bowling)
                .WithOne(x => x.Game)
                .HasForeignKey<Bowling>(x => x.GameId);

            modelBuilder
                .Entity<Game>()
                .HasOne(x => x.Fielding)
                .WithOne(x => x.Game)
                .HasForeignKey<Fielding>(x => x.GameId);

            modelBuilder
                .Entity<Bowling>()
                .HasMany(x => x.WicketsInformation)
                .WithOne(x => x.Bowling);

            modelBuilder
                .Entity<Wicket>()
                .HasOne(x => x.Bowling)
                .WithMany(x => x.WicketsInformation)
                .HasForeignKey(x => x.BowlingId);

            modelBuilder
                .Entity<Game>();

            modelBuilder
                .Entity<Result>();

            modelBuilder
                .Entity<GameLocation>();

            modelBuilder
                .Entity<Batting>();

            modelBuilder
                .Entity<Bowling>();

            modelBuilder
                .Entity<Fielding>();

            modelBuilder
                .Entity<Wicket>();
        }
    }
}
