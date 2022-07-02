namespace MVCNedir.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCNedir.Models.AdimAdimDBModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MVCNedir.Models.AdimAdimDBModel context)
        {
            context.ManagerTypes.AddOrUpdate(s => s.ID, new Models.ManagerType() { ID = 1, Name = "Admin" });
            context.ManagerTypes.AddOrUpdate(s => s.ID, new Models.ManagerType() { ID = 2, Name = "Moderatör" });

            context.Managers.AddOrUpdate(s => s.ID, new Models.Manager() { ID = 1, ManagerType_ID = 1, Name = "John", Surname = "Doe", Email = "johndoe26@hotmail.com", Password = "1234", Status = true });
        }
    }
}
