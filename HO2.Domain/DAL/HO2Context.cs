using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HO2.Domain.Migrations;
using System.Data.Common;
using System.Data;
using System.Threading.Tasks;
using HO2.Domain.Models;

namespace HO2.Domain.DAL
{
    public class HO2Context : DbContext , IHO2Context
    {
        static HO2Context()
        {
            Database.SetInitializer(new DataContextMigratorConfiguration());
        }

        public static readonly string DefaultConnection = "DefaultConnection";
        public HO2Context() : base(DefaultConnection) { }
        public HO2Context(DbConnection connection) : base(connection, false) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            var mate = modelBuilder.Entity<Mate>();
            mate.HasKey(x => x.Id);

            var vote = modelBuilder.Entity<Vote>();
            vote.HasKey(x => x.Id);

            var place = modelBuilder.Entity<Place>();
            place.HasKey(x => x.Id);

            var friendgroup = modelBuilder.Entity<FriendGroup>();
            friendgroup.HasKey(x => x.Id);

            friendgroup.
                HasMany(c => c.Mates).
                WithMany(p => p.FriendGroups).
                Map(
                    m =>
                    {
                        m.MapLeftKey("FriendGroup.Id");
                        m.MapRightKey("Mate.Id");
                        m.ToTable("MateFriendGroup");
                    });
        }


        IDbSet<TEntity> IHO2Context.Set<TEntity>()
        {
            return Set<TEntity>();
        }

        public void Save()
        {
            base.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }

        public DbContextTransaction BeginTransaction()
        {
            return Database.BeginTransaction();
        }

        public DbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return Database.BeginTransaction(isolationLevel);
        }
    }
}