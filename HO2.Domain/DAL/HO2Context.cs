

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HO2.Domain.Migrations;
using HO2.Domain.Models.Business;

namespace HO2.Domain.DAL
{
    public class HO2Context : DbContext , IHO2Context
    {
        public HO2Context() : base("HO2Context.Web")
        {
          
        }
        public HO2Context(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<HO2Context>(new CreateDatabaseIfNotExists<HO2Context>());
            Database.SetInitializer<HO2Context>(new MigrateDatabaseToLatestVersion<HO2Context, Configuration>());
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