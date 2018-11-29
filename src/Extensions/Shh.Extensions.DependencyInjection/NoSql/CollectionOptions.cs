using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Extensions.DependencyInjection.NoSql
{
    public class NoSqlCollectionOptions<T>
    {
        public CollectionOptions Value { get; set; }
    }

    public class CollectionOptions
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
