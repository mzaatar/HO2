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
}
