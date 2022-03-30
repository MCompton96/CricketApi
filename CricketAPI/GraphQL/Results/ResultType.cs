using CricketAPI.Data;
using CricketAPI.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.Results
{
    public class ResultType : ObjectType<Result>
    {
        protected override void Configure(IObjectTypeDescriptor<Result> descriptor)
        {
            descriptor
                .Field(x => x.Id)
                .Description("Represents the uniqe id for the result");

            descriptor
                .Field(x => x.Method)
                .Description("Represents the method of result wickets/runs");

            descriptor
                .Field(x => x.By)
                .Description("Represents the quantity of result");

            descriptor
                .Field(x => x.Won)
                .Description("Represents whether the user won or lost the game");

            descriptor
                .Field(x => x.Game)
                .Name("game")
                .ResolveWith<Resolvers>(x => x.GetGame(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Game associated with result");
        }
        private class Resolvers
        {
            public Game GetGame([Parent] Result result, [ScopedService] AppDbContext context)
            {
                return context.Games.FirstOrDefault(x => x.Id == result.GameId);
            }
        }
    }
}
