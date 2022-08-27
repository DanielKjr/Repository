using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private readonly string connectionString;

        /// <summary>
        /// Takes a string parameter to create connection to a database through SQLite.
        /// <para>Example: "Data Source=databasename.db"</para> 
        /// </summary>
        /// <param name="_connectionString"></param>
        public DatabaseProvider(string _connectionString)
        {
            connectionString = _connectionString;
        }

        /// <summary>
        /// Returns new SQLiteConnection using the DatabaseProviders' connectionString.
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}
