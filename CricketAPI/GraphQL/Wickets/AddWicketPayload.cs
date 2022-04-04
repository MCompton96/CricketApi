using CricketAPI.Models;
using System.Collections.Generic;

namespace CricketAPI.GraphQL.Wickets
{
    public record AddWicketPayload(
        IReadOnlyCollection<Wicket> wickets    
    );
}
