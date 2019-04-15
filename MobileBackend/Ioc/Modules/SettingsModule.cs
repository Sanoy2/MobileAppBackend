using Autofac;
using Microsoft.Extensions.Configuration;
using MobileBackend.Extensions;
using MobileBackend.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MobileBackend.Ioc.Modules
{
    public class SettingsModule :Autofac.Module
    {
        private readonly IConfiguration configuration;

        public SettingsModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(configuration.GetSettings<GeneralSettings>())
                .SingleInstance();
        }
    }
}
