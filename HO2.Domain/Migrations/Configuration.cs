using System.Collections.Generic;
using System.Data.Entity;
using HO2.Domain.DAL;
using HO2.Domain.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace HO2.Domain.Migrations
{
    public class DataContextMigratorConfiguration : MigrateDatabaseToLatestVersion<HO2Context, DataContextMigrator>
    {
        public DataContextMigratorConfiguration()
        {
            Database.SetInitializer<HO2Context>(new CreateDatabaseIfNotExists<HO2Context>());
        }
    }

    public class DataContextMigrator : DbMigrationsConfiguration<HO2Context>
    {
        public DataContextMigrator()
        {
            AutomaticMigrationDataLossAllowed = false;
            AutomaticMigrationsEnabled = false;
        }
    }

    //internal sealed class Configuration : DbMigrationsConfiguration<HO2Context>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = false;
    //    }

    //    protected override void Seed(HO2Context context)
    //    {
    //        if (context.Database.Exists())
    //            return;
            
    //        var mates = new List<Mate>()
    //        {
    //            new Mate { Email =  "Cormac.Long@readify.net" , FirstName = "Cormac", LastName = "Long"},
    //            new Mate { Email =  "Mohamed.Zaatar@readify.net", FirstName = "Mohamed", LastName = "Zaatar"},
    //        };
    //        mates.ForEach(s => context.Mates.Add(s));
    //        context.SaveChanges();

    //        var groups = new List<FriendGroup>
    //        {
    //            new FriendGroup {FriendGroupName = "Readify WA" , FriendGroupDetails = "Readify WA Group" , FriendGroupAdminUser = mates.FirstOrDefault()},
    //            new FriendGroup {FriendGroupName = "Folk" , FriendGroupDetails = "Folk WA Group" , FriendGroupAdminUser = mates.FirstOrDefault()}
    //        };

    //        groups.ForEach(g => context.Groups.Add(g));
    //        context.SaveChanges();

    //        foreach (var u in mates)
    //        {
    //            u.FriendGroups.Add(groups.FirstOrDefault());
    //        }
    //        context.SaveChanges();


    //        var places = new List<Place>()
    //        {
    //            new Place { PlaceName = "Cambridge Library"},
    //            new Place { PlaceName = "Ezra Pound"},
    //        };
    //        places.ForEach(s => context.Places.Add(s));
    //        context.SaveChanges();

           
    //    }
    //}
}
