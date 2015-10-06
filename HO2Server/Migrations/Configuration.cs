using System.Collections.Generic;
using HO2Server.Models.Business;

namespace HO2Server.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HO2Server.DAL.HO2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HO2Server.DAL.HO2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var mates = new List<Mate>()
            {
                new Mate { Email =  "Cormac.Long@readify.net" , FirstName = "Cormac", LastName = "Long"},
                new Mate { Email =  "Mohamed.Zaatar@readify.net", FirstName = "Mohamed", LastName = "Zaatar"},
            };
            mates.ForEach(s => context.Mates.Add(s));
            context.SaveChanges();

            var groups = new List<FriendGroup>
            {
                new FriendGroup {FriendGroupName = "Readify WA" , FriendGroupDetails = "Readify WA Group" , FriendGroupAdminUser = mates.FirstOrDefault()},
                new FriendGroup {FriendGroupName = "Folk" , FriendGroupDetails = "Folk WA Group" , FriendGroupAdminUser = mates.FirstOrDefault()}
            };

            groups.ForEach(g => context.Groups.Add(g));
            context.SaveChanges();

            foreach (var u in mates)
            {
                u.FriendGroups.Add(groups.FirstOrDefault());
            }
            context.SaveChanges();


            var places = new List<Place>()
            {
                new Place { PlaceName = "Cambridge Library"},
                new Place { PlaceName = "Ezra Pound"},
            };
            places.ForEach(s => context.Places.Add(s));
            context.SaveChanges();

           
        }
    }
}
