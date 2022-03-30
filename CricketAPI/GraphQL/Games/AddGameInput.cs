using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.Games
{
    public record AddGameInput(
        string Opponent,
        DateTime Date,
        bool Home,
        string Ground,
        bool Won,
        int By,
        string Method
    );
}
