using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.Wickets
{
    public record AddWicketInput(
        string Type,
        string Area
    );
}
