using CricketAPI.Data;
using CricketAPI.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.Wickets
{
    public class WicketType : ObjectType<Wicket>
    {
        protected override void Configure(IObjectTypeDescriptor<Wicket> descriptor)
        {
            descriptor
                .Field(x => x.Id)
                .Description("Represents the unique id for the wicket.");

            descriptor
                .Field(x => x.Bowling)
                .ResolveWith<Resolvers>(x => x.GetBowling(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Represents the bowling session associated with wicket");

            descriptor
                .Field(x => x.Type)
                .Description("Represents the method that the wicket was taken");

            descriptor
                .Field(x => x.Area)
                .Description("Represents the coordinates on the wicket where the wicket was taken");
        }

        private class Resolvers
        {
            public Bowling GetBowling([Parent] Wicket wicket, [ScopedService] AppDbContext context)
            {
                return context.Bowlings.FirstOrDefault(x => x.Id == wicket.BowlingId);
            }
        }
    }
}
