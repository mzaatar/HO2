

using System.Data.Entity;
using HO2Server.Models.Business;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HO2Server.DAL
{
    public class HO2Context : DbContext , IHO2Context
    {

        public HO2Context() : base("HO2Context")
        {
        }

        public IDbSet<FriendGroup> Groups { get; set; }
        public IDbSet<Mate> Mates { get; set; }
        public IDbSet<Vote> Votes { get; set; }
        public IDbSet<Place> Places { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<FriendGroup>().
                HasMany(c => c.Mates).
                WithMany(p => p.FriendGroups).
                Map(
                    m =>
                    {
                        m.MapLeftKey("FriendGroupId");
                        m.MapRightKey("UserId");
                        m.ToTable("UserFriendGroup");
                    });

        }
    }
}