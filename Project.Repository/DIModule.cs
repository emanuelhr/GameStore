using Autofac;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class DIModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CartRepository>().As<ICartRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<StoreContext>().As<IStoreContext>().InstancePerLifetimeScope() ;
            builder.RegisterType<DeveloperRepository>().As<IDeveloperRepository>();

            builder.RegisterType<Developer>().As<IDeveloper>();
           // builder.RegisterType<Repository<ICart>
           
        }

    }
}
