﻿using Autofac;
using Shh.Services.Noise.Application.Queries;
using Shh.Services.Noise.Domain.AggregateModels;
using Shh.Services.Noise.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Services.Noise.Infrastructure.AutofacModules
{
    public class NoiseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterDatabase(builder);
        }

        private void RegisterDatabase(ContainerBuilder builder)
        {
            builder.RegisterType<NoiseRepository>()
                .As<INoiseRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<NoiseQueries>()
                .As<INoiseQueries>()
                .InstancePerLifetimeScope();
        }
    }
}