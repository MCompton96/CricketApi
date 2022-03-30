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
                .HasData(
                new Game
                { Id = Guid.Parse("b78f32c7-caa6-4a27-8043-ca8d704d18be"), Date = new DateTime(2022, 01, 01), Opponent = "Bury" },
                new Game
                { Id = Guid.Parse("5e0da44f-0c77-4811-9509-71d3f5a4e055"), Date = new DateTime(2022, 02, 01), Opponent = "Eccles"},
                new Game
                { Id = Guid.Parse("07950e05-2ac6-4566-bcf4-37a475d134c0"), Date = new DateTime(2022, 02, 08), Opponent = "Worsley"},
                new Game
                { Id = Guid.Parse("31964ae0-bb3e-4f14-b201-8cc64a866f46"), Date = new DateTime(2022, 02, 15), Opponent = "Wilmslow"}
            );

            modelBuilder
                .Entity<Result>()
                .HasData(
                new Result
                { Id = Guid.Parse("89a144e7-e231-4994-8427-0ffe484b4a62"), GameId = Guid.Parse("b78f32c7-caa6-4a27-8043-ca8d704d18be"), Won = true, By = 42, Method = "Runs" },
                new Result
                { Id = Guid.Parse("af553dcb-03ae-4d8c-8f64-3a2e90a57c83"), GameId = Guid.Parse("5e0da44f-0c77-4811-9509-71d3f5a4e055"), Won = false, By = 7, Method = "Wickets" },
                new Result
                { Id = Guid.Parse("78717cc7-4111-4414-8303-5d5cbbf52139"), GameId = Guid.Parse("07950e05-2ac6-4566-bcf4-37a475d134c0"), Won = true, By = 5, Method = "Wickets" },
                new Result
                { Id = Guid.Parse("724966b4-738e-4c6e-a5db-41e77f6a23d5"), GameId = Guid.Parse("31964ae0-bb3e-4f14-b201-8cc64a866f46"), Won = false, By = 110, Method = "Runs" }
            );

            modelBuilder
                .Entity<GameLocation>()
                .HasData(
                new GameLocation
                { Id = Guid.Parse("dd068f1b-30f2-41f4-9e21-2f7ee42fde1b"), GameId = Guid.Parse("b78f32c7-caa6-4a27-8043-ca8d704d18be"), Home = true, Ground = "Whalley Range" },
                new GameLocation
                { Id = Guid.Parse("8a327c74-f7f7-4a2b-973e-dd2178d329ee"), GameId = Guid.Parse("5e0da44f-0c77-4811-9509-71d3f5a4e055"), Home = false, Ground = "Bury" },
                new GameLocation
                { Id = Guid.Parse("cd8ce9de-84c1-44a6-92e7-42707f78ac8a"), GameId = Guid.Parse("07950e05-2ac6-4566-bcf4-37a475d134c0"), Home = false, Ground = "Worsley" },
                new GameLocation
                {  Id = Guid.Parse("5074cab6-aabf-460e-a90f-6f982033714d"), GameId = Guid.Parse("31964ae0-bb3e-4f14-b201-8cc64a866f46"), Home = true, Ground = "Whalley Range" }
            );

            modelBuilder
                .Entity<Batting>()
                .HasData(
                new Batting
                { Id = Guid.Parse("fee0d6c9-0249-4f52-94e6-5cb4686e49b4"), GameId = Guid.Parse("b78f32c7-caa6-4a27-8043-ca8d704d18be"), Out = true, Runs = 42, Boundaries = 5, Sixes = 3 },
                new Batting
                { Id = Guid.Parse("d30fab19-0ac0-4875-9479-15edd6384dae"), GameId = Guid.Parse("5e0da44f-0c77-4811-9509-71d3f5a4e055"), Out = false, Runs = 11, Boundaries = 2, Sixes = 0 },
                new Batting
                { Id = Guid.Parse("be5c0c50-668d-4f55-97ec-bf3dd95bf16f"), GameId = Guid.Parse("07950e05-2ac6-4566-bcf4-37a475d134c0"), Out = true, Runs = 72, Boundaries = 10, Sixes = 2 },
                new Batting
                { Id = Guid.Parse("274fe76b-91ad-4ef1-bf07-bd25d8925273"), GameId = Guid.Parse("31964ae0-bb3e-4f14-b201-8cc64a866f46"), Out = true, Runs = 33, Boundaries = 5, Sixes = 2 }
            );

            modelBuilder
                .Entity<Bowling>()
                .HasData(
                new Bowling
                { Id = Guid.Parse("ffecdf7f-dcab-4bef-9e36-e9df5373a01e"), GameId = Guid.Parse("b78f32c7-caa6-4a27-8043-ca8d704d18be"), Overs = 6, Runs = 34, Wickets = 3, Maidens = 1 },
                new Bowling
                { Id = Guid.Parse("de967516-2d69-4721-a055-1ce917a55fcd"), GameId = Guid.Parse("5e0da44f-0c77-4811-9509-71d3f5a4e055"), Overs = 8, Runs = 41, Wickets = 2, Maidens = 2 },
                new Bowling
                {  Id = Guid.Parse("d7678a77-628b-407e-b6a8-c13b8b9de529"), GameId = Guid.Parse("07950e05-2ac6-4566-bcf4-37a475d134c0"), Overs = 5, Runs = 18, Wickets = 0, Maidens = 4 },
                new Bowling
                {  Id = Guid.Parse("efe01505-b8b2-4038-aa72-84aa060380a0"), GameId = Guid.Parse("31964ae0-bb3e-4f14-b201-8cc64a866f46"), Overs = 11, Runs = 42, Wickets = 5, Maidens = 3 }
            );
        }
    }
}
