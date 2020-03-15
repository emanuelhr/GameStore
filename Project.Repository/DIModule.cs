using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using AutoMapper;
using Project.DAL;
using Project.Repository.Common;

namespace Project.Repository
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStoreContext>().To<StoreContext>().InSingletonScope();
            Bind<ICartRepository>().To<CartRepository>();
           // Bind<IDeveloperRepository>().To<DeveloperRepository>();

        }

    }
}
