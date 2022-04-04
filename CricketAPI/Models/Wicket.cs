using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CricketAPI.Models
{
    public class Wicket
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid BowlingId { get; set; }

        public Bowling Bowling { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Area { get; set; }
    }
}
