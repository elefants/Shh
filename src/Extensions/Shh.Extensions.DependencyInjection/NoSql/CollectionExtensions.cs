using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Extensions.DependencyInjection.NoSql
{
    public static class CollectionExtensions
    {
        public static IServiceCollection AddNoSqlCollection<T>(this IServiceCollection services, Action<NoSqlCollectionOptions<T>> setup)
        {
            var options = new NoSqlCollectionOptions<T>();
            setup?.Invoke(options);

            services.AddSingleton(options);

            return services;
        }
    }
}
