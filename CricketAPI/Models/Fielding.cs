using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.Models
{
    public class Fielding
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid GameId { get; set; }

        public Game Game { get; set; }

        [Required]
        public int Catches { get; set; } = 0;

        [Required]
        public int RunOuts { get; set; } = 0;
    }
}
