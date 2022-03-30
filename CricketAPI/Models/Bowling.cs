using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.Models
{
    public class Bowling
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid GameId { get; set; }

        public Game Game { get; set; }

        public int Overs { get; set; } = 0;

        public int Wickets { get; set; } = 0;

        public int Runs { get; set; } = 0;

        public int Maidens { get; set; } = 0;
    }
}
