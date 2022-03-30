using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.Battings
{
    public record AddBattingInput(
        Guid GameId,
        int Runs,
        bool Out,
        int Boundaries,
        int Sixes
    );
}
