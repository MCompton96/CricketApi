using CricketAPI.Data;
using CricketAPI.Models;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL
{
    [GraphQLDescription("Represents the queries avaialble")]
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [Authorize]
        public IQueryable<Game> GetGame([ScopedService] AppDbContext context)
        {
            return context.Games;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [Authorize]
        public IQueryable<Batting> GetBatting([ScopedService] AppDbContext context)
        {
            return context.Battings;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [Authorize]
        public IQueryable<Bowling> GetBowling([ScopedService] AppDbContext context)
        {
            return context.Bowlings;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [Authorize]
        public IQueryable<Result> GetResult([ScopedService] AppDbContext context)
        {
            return context.Results;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [Authorize]
        public IQueryable<GameLocation> GetLocation([ScopedService] AppDbContext context)
        {
            return context.GmeLocations;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [Authorize]
        public IQueryable<Wicket> GetWicket([ScopedService] AppDbContext context)
        {
            return context.Wickets;
        }
    }
}
