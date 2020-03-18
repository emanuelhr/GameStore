﻿using Autofac;
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
           
        }

    }
}
