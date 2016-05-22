using Infra.Data.Context;
using SimpleInjector;

namespace CrossCutting.IoC.SimpleInjectorConfig
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            //container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            //container.Register<ApplicationSignInManager>(Lifestyle.Scoped);


            //Apllication Layer


            //Domain Layer


            //Repository Layer

            //Context
            container.Register<AppDbContext, AppDbContext>(Lifestyle.Scoped);
        }
    }
}