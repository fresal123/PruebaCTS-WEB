namespace PruebaCTS.UI.Data
{
    public class SqlConfiguration
    {
        public string ConnectionString { get;  }

        public SqlConfiguration(string connectionString) => ConnectionString = connectionString;
    }
}
