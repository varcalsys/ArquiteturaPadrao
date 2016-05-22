namespace Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Context;
    using Core;

    internal sealed class Configuration : DbMigrationsConfiguration<Infra.Data.Context.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDbContext context)
        {
            var c = new Core.Migrations.Configuration();

            c.CargaInicial();
        }
    }
}
