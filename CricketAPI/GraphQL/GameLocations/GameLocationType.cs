using CricketAPI.Data;
using CricketAPI.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.GameLocations
{
    public class GameLocationType : ObjectType<GameLocation>
    {
        protected override void Configure(IObjectTypeDescriptor<GameLocation> descriptor)
        {
            descriptor
                .Field(x => x.Id)
                .Description("Represents the unique id for the game location");

            descriptor
                .Field(x => x.Home)
                .Description("Boolean value for whether the game was played at home or not");

            descriptor
                .Field(x => x.Ground)
                .Description("Represents the ground where the game was played");

            descriptor
                .Field(x => x.Game)
                .ResolveWith<Resolvers>(x => x.GetGame(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Game associated with location");
        }
        private class Resolvers
        {
            public Game GetGame([Parent] GameLocation location, [ScopedService] AppDbContext context)
            {
                return context.Games.FirstOrDefault(x => x.Id == location.GameId);
            }
        }
    }
}
