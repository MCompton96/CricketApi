using CricketAPI.Data;
using CricketAPI.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.Games
{
    public class GameType : ObjectType<Game>
    {
        protected override void Configure(IObjectTypeDescriptor<Game> descriptor)
        {
            descriptor
                .Field(x => x.Id)
                .Description("Represents the unique id for the game.");

            descriptor
                .Field(x => x.Date)
                .Description("Represents the date the game was played");

            descriptor
                .Field(x => x.Opponent)
                .Description("Represents the opponent of the game");

            descriptor
                .Field(x => x.Result)
                .Name("result")
                .ResolveWith<Resolvers>(x => x.GetResult(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Result associated with game");

            descriptor
                .Field(x => x.Batting)
                .Name("batting")
                .ResolveWith<Resolvers>(x => x.GetBatting(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Batting stats associated with game");

            descriptor
                .Field(x => x.Bowling)
                .Name("bowling")
                .ResolveWith<Resolvers>(x => x.GetBowling(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Bowling stats associated with game");

            descriptor
                .Field(x => x.Location)
                .Name("location")
                .ResolveWith<Resolvers>(x => x.GetLocation(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Location information associated with game");
        }

        private class Resolvers
        {
            public Result GetResult([Parent] Game game, [ScopedService] AppDbContext context)
            {
                return context.Results.FirstOrDefault(x => x.GameId == game.Id);
            }

            public GameLocation GetLocation([Parent] Game game, [ScopedService] AppDbContext context)
            {
                return context.GmeLocations.FirstOrDefault(x => x.GameId == game.Id);
            }

            public Batting GetBatting([Parent] Game game, [ScopedService] AppDbContext context)
            {
                return context.Battings.FirstOrDefault(x => x.GameId == game.Id);
            }

            public Bowling GetBowling([Parent] Game game, [ScopedService] AppDbContext context)
            {
                return context.Bowlings.FirstOrDefault(x => x.GameId == game.Id);
            }
        }
    }
}
