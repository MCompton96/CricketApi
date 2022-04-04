using CricketAPI.Data;
using CricketAPI.GraphQL.Battings;
using CricketAPI.GraphQL.Bowlings;
using CricketAPI.GraphQL.Games;
using CricketAPI.GraphQL.Users;
using CricketAPI.Models;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CricketAPI.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        [Authorize]
        public async Task<AddGamePayload> AddGameAsync(
            AddGameInput input,
            [ScopedService] AppDbContext context
        )
        {
            var game = new Game
            {
                Opponent = input.Opponent,
                Date = input.Date
            };

            context.Games.Add(game);
            await context.SaveChangesAsync();

            var location = new GameLocation
            {
                GameId = game.Id,
                Home = input.Home,
                Ground = input.Ground
            };

            context.GmeLocations.Add(location);
            await context.SaveChangesAsync();

            var result = new Result
            {
                GameId = game.Id,
                Won = input.Won,
                By = input.By,
                Method = input.Method
            };

            context.Results.Add(result);
            await context.SaveChangesAsync();

            return new AddGamePayload(
                game,
                location,
                result
            );
        }

        [UseDbContext(typeof(AppDbContext))]
        [Authorize]
        public async Task<AddBowlingPayload> AddBowlingAsync(
            AddBowlingInput input,
            [ScopedService] AppDbContext context
        )
        {
            var bowling = new Bowling
            {
                GameId = input.GameId,
                Overs = input.Overs,
                Wickets = input.Wickets,
                Runs = input.Runs,
                Maidens = input.Maidens
            };

            context.Bowlings.Add(bowling);
            await context.SaveChangesAsync();

            var wickets = input.WicketsInformation.Select(x => new Wicket
            {
                Area = x.Area,
                Type = x.Type,
                BowlingId = bowling.Id
            })
            .ToList();

            context.Wickets.AddRange(wickets);
            await context.SaveChangesAsync();

            return new AddBowlingPayload(bowling, wickets);
        }

        [UseDbContext(typeof(AppDbContext))]
        [Authorize]
        public async Task<AddBattingPayload> AddBattingAsync(
            AddBattingInput input,
            [ScopedService] AppDbContext context
        )
        {
            var batting = new Batting
            {
                GameId = input.GameId,
                Runs = input.Runs,
                Out = input.Out,
                Boundaries = input.Boundaries,
                Sixes = input.Sixes
            };

            context.Battings.Add(batting);
            await context.SaveChangesAsync();

            return new AddBattingPayload(batting);
        }

        [UseDbContext(typeof(AppDbContext))]
        public string Login(
            LoginInput input,
            [ScopedService] AppDbContext context,
            [Service] IOptions<TokenSettings> tokenSettings
        )
        {
            var currentUser = context.Users.Where(x => x.Email.ToLower() == input.Email &&
            x.Password == input.Password).FirstOrDefault();

            if (currentUser != null)
            {
                var symmetricSymmetryKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.Key));
                var credentials = new SigningCredentials(symmetricSymmetryKey, SecurityAlgorithms.HmacSha256);

                var claims = new Claim[] {
                    new Claim(ClaimTypes.Role, "user")
                };

                var jwtTokem = new JwtSecurityToken(
                        issuer: tokenSettings.Value.Issuer,
                        audience: tokenSettings.Value.Audience,
                        expires: DateTime.UtcNow.AddMinutes(50),
                        signingCredentials: credentials,
                        claims: claims
                    );

                string token = new JwtSecurityTokenHandler().WriteToken(jwtTokem);
                return token;
            }

            return string.Empty;
        }
    }
}
