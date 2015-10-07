using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HO2.Domain.Models
{
    public class FriendGroup :IModel
    {
        public FriendGroup()
        {
            this.Mates = new List<Mate>();
        }

        [Required]
        [MaxLength(100)]
        public string FriendGroupName { get; set; }


        [MaxLength(500)]
        public string FriendGroupDetails { get; set; }

        [Column("AdminUserID")]
        public Mate FriendGroupAdminUser { get; set; }


        [JsonIgnore]
        public virtual  IList<Mate> Mates { get; set; }

        }
}