﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCTS.UI.Data
{
    public class SqlConfiguration
    {
        public string ConnectionString { get;  }

        public SqlConfiguration(string connectionString) => ConnectionString = connectionString;
    }
}
