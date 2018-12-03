using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Extensions.DependencyInjection.NoSql
{
    public static class CollectionExtensions
    {
        public static IServiceCollection AddNoSqlCollection<T>(this IServiceCollection services, IConfigurationSection config)
            where T : class
        {
            var options = new CollectionOptions();
            config.Bind(options);

            var c = new NoSqlCollectionOptions<T>
            {
                Value = options
            };

            return services
                .AddNoSqlCollection(c)
                .AddTransient<T>();
        }

        public static IServiceCollection AddNoSqlCollection<T>(this IServiceCollection services, Action<NoSqlCollectionOptions<T>> setup)
        {
            var options = new NoSqlCollectionOptions<T>();
            setup?.Invoke(options);

            return services.AddNoSqlCollection(options);
        }

        private static IServiceCollection AddNoSqlCollection<T>(this IServiceCollection services, NoSqlCollectionOptions<T> settings)
        {
            services.AddSingleton(settings);

            return services;
        }
    }
}
