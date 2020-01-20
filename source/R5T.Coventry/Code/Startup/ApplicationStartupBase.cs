﻿using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Derby.Extensions;
using R5T.Ives;
using R5T.Ives.Configuration;

using RichmondApplicationStartupBase = R5T.Richmond.ApplicationStartupBase;


namespace R5T.Coventry
{
    /// <summary>
    /// Adds default and configuration name-specific JSON AppSettings files, and console logging and a configuration name provider.
    /// </summary>
    public abstract class ApplicationStartupBase : RichmondApplicationStartupBase
    {
        public ApplicationStartupBase(ILogger<ApplicationStartupBase> logger)
            : base(logger)
        {
        }

        /// <summary>
        /// Adds default- and configuration name-specific appsettings.json files.
        /// </summary>
        protected override void ConfigureConfigurationBody(IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            configurationBuilder
                .AddDefaultAndConfigurationSpecificAppSettingsJsonFiles(configurationServiceProvider, true) // Make the configuration-name-specific appsettings file optional since all configuration might just be in the default appsettings file.
                ;
        }

        /// <summary>
        /// Adds console logging and <see cref="IConfigurationNameProvider"/>.
        /// </summary>
        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConsole();
                })
                .AddSingleton<IConfigurationNameProvider, DirectConfigurationBasedConfigurationNameProvider>()
                ;
        }
    }
}
