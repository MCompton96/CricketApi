using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.Models
{
    public class Batting
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid GameId { get; set; }

        public Game Game { get; set; }

        [Required]
        public int Runs { get; set; } = 0;

        [Required]
        public bool Out { get; set; }

        public int Boundaries { get; set; } = 0;

        public int Sixes { get; set; } = 0;
    }
}
