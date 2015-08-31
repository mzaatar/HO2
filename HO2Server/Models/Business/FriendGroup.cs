using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HO2Server.Models.Business
{
    public class FriendGroup
    {
        public FriendGroup()
        {
            this.Users = new List<User>();
        }

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FriendGroupId { get; set; }


        [Required]
        [MaxLength(100)]
        public string FriendGroupName { get; set; }


        [MaxLength(500)]
        public string FriendGroupDetails { get; set; }

        [Column("AdminUserID")]
        public User FriendGroupAdminUser { get; set; }


        public virtual  IList<User> Users { get; set; }

        }
}