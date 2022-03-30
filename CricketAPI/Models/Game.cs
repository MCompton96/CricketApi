using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.Models
{
    public class Game
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Opponent { get; set; }

        public Result Result { get; set; }

        public GameLocation Location { get; set; }

        public Batting Batting { get; set; }

        public Bowling Bowling { get; set; }
    }
}
