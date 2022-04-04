using CricketAPI.GraphQL.Wickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.Bowlings
{
    public record AddBowlingInput(
        Guid GameId,
        int Overs,
        int Wickets,
        int Runs,
        int Maidens,
        IReadOnlyCollection<AddWicketInput> WicketsInformation
    );
}
