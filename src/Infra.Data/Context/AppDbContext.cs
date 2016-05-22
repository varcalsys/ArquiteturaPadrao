using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Infra.Data.Context
{
    public class AppDbContext: DbContext
    {

        public AppDbContext():base("Name=DefaultConnection")
        {
                
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(x=>x.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(x=>x.HasMaxLength(50));

            base.OnModelCreating(modelBuilder);
        }
    }
}
