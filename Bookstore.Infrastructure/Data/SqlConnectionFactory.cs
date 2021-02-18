using Bookstore.Application.Configuration.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure.Data
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public SqlConnectionFactory()
        {
            _connectionString = "Server=DESKTOP-LFP7NKR\\SQLEXPRESS;Database=Bookstore;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        public IDbConnection GetOpenConnection()
        {
            if(_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }
        public void Dispose()
        {
            if(_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }
        }
    }
}
