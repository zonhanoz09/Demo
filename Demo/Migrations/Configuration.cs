namespace Demo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Demo.Models.DemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //for client team
            //AutomaticMigrationsEnabled = false; //for server team
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Demo.Models.DemoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
