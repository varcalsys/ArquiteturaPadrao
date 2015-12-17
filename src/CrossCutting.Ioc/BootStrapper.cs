
using App.Contracts;
using App.Services;
using CrossCutting.Identity.Configuration;
using CrossCutting.Identity.Context;
using CrossCutting.Identity.Models;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Services;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;

namespace CrossCutting.Ioc
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {

            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);


            //Apllication Layer
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));


            //Domain Layer
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));


            //Repository Layer
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            //Context
            container.Register<AppDbContext, AppDbContext>();
        }
    }
}
