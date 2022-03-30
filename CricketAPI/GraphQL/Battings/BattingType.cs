using CricketAPI.Data;
using CricketAPI.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.Battings
{
    public class BattingType : ObjectType<Batting>
    {
        protected override void Configure(IObjectTypeDescriptor<Batting> descriptor)
        {
            descriptor
                .Field(x => x.Id)
                .Description("Represents the unique id for batting stats");

            descriptor
                .Field(x => x.Out)
                .Description("Boolean value on whether batter was out or not");

            descriptor
                .Field(x => x.Boundaries)
                .Description("Represents the quantity of boundaries scored for an innings");

            descriptor
                .Field(x => x.Sixes)
                .Description("Represents the quantity of sixes scored in an innings");

            descriptor
                .Field(x => x.Game)
                .ResolveWith<Resolvers>(x => x.GetGame(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Represents the game associated with the batting stats");
        }
        private class Resolvers
        {
            public Game GetGame([Parent] Batting batting, [ScopedService] AppDbContext context)
            {
                return context.Games.FirstOrDefault(x => x.Id == batting.GameId);
            }
        }
    }
}
