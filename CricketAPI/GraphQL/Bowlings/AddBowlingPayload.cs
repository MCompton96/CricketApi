using CricketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.Bowlings
{
    public record AddBowlingPayload(
        Bowling bowling        
    );
}
