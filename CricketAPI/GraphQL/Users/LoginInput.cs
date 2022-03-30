using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL.Users
{
    public record LoginInput(
        string Email,
        string Password
    );
}
