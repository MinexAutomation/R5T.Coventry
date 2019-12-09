﻿using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Derby;
using R5T.Richmond;


namespace R5T.Coventry.Construction
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.TryGetValue01();
        }

        private static void TryGetValue01()
        {
            var serviceProvider = Program.GetServiceProvider();

            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            var value01 = configuration["Value01"];

            Console.WriteLine($"Value01: {value01}");
        }

        private static IServiceProvider GetServiceProvider()
        {
            var serviceProvider = ApplicationBuilder.UseStartup<Startup, ApplicationConfigurationStartup>();
            return serviceProvider;
        }
    }
}
