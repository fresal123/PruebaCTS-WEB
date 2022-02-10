using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCTS.API.Manager
{
    public class SqlConfiguration
    {
        public string ConnectionString { get; set; }

        public SqlConfiguration(string connectionString) => ConnectionString = connectionString;
    }
}
