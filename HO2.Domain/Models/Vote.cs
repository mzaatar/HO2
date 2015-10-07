using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HO2.Domain.Models;

namespace HO2.Domain.Models
{
    public class Vote
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoteId { get; set; }

        [Required]
        public DateTime UpdateDateTime { get; set; }

        [Required]
        public FriendGroup FriendGroup { get; set; }
        [Required]
        public Mate Mate { get; set; }
        [Required]
        public DateTime SuggestedDateTime { get; set; }
        [Required]
        public Place Place { get; set; }

    }
}