namespace ExpensesBackend.Migrations
{
    using ExpensesBackend.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExpensesBackend.DatabaseContext.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExpensesBackend.DatabaseContext.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //context.Entries.Add(new Entry { Description = "First Entry", IsExpense = true, Value = 100 });
            //context.Entries.Add(new Entry { Description = "Second Entry", IsExpense = false, Value = 200 });
            context.SaveChanges();

        }
    }
}
