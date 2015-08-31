using System.Collections.Generic;
using HO2Server.Models.Business;

namespace HO2Server.Migrations
{
    using System;
    using System.Data.Entity;
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
            var users = new List<User>()
            {
                new User { UserName =  "CLong" , FirstName = "Cormac", LastName = "Long"},
                new User { UserName =  "MZaatar", FirstName = "Moahmed", LastName = "Zaatar"},
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var groups = new List<FriendGroup>
            {
                new FriendGroup {FriendGroupName = "Readify WA" , FriendGroupDetails = "Readify WA Group" , FriendGroupAdminUser = users.Find(s=>s.UserName == "MZAATAR")},
                new FriendGroup {FriendGroupName = "Folk" , FriendGroupDetails = "Folk WA Group" , FriendGroupAdminUser = users.Find(s=>s.UserName == "CLONG")}
            };

            groups.ForEach(g => context.Groups.Add(g));
            context.SaveChanges();

        }
    }
}
