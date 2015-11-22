using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.Identity.Configuration;
using CrossCutting.Identity.Context;
using CrossCutting.Identity.Models;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services.Core;
using Domain.Services.Core;
using Infra.Data.AppContext;
using Infra.Data.Repositories.Core;
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

            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));

            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }
    }
}
