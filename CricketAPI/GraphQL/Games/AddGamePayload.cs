using CricketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.Games
{
    public record AddGamePayload(
        Game game,
        GameLocation location,
        Result result
    );
}
