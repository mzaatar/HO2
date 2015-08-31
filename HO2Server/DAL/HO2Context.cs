

using System.Data.Entity;
using HO2Server.Models.Business;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HO2Server.DAL
{
    public class HO2Context : DbContext
    {

        public HO2Context() : base("HO2Context")
        {
        }

        public DbSet<FriendGroup> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Place> Places { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<FriendGroup>().
                HasMany(c => c.Users).
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