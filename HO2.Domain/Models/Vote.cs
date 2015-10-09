using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HO2.Domain.Models;

namespace HO2.Domain.Models
{
    public class Vote : IModel
    {
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