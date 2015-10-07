using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HO2.Domain.Models
{
    public class Mate
    {
        public Mate()
        {
            this.FriendGroups = new List<FriendGroup>();
        }
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int MateId { get; set; }

        [Required]
        [MaxLength(100)]
        [Index("IX_UniqueEmail", IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [JsonIgnore]
        public virtual IList<FriendGroup> FriendGroups { get; set; }
    }
}