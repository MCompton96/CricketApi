using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricketAPI.Models
{
    public class Result
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid GameId { get; set; }

        public Game Game { get; set; }

        [Required]
        public bool Won { get; set; }

        [Required]
        public int By { get; set; }

        [Required]
        public string Method { get; set; }
    }
}
