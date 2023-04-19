namespace Demo_MVC.Migrations
{
    using Demo_MVC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Demo_MVC.Models.DemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Demo_MVC.Models.DemoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            context.Demos.Add(new Demo { Username = "Ishan", Password = "Ishan123", Role = "Admin" });
            context.Demos.Add(new Demo { Username = "Ishu", Password = "Ishu123", Role = "Employee" });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
