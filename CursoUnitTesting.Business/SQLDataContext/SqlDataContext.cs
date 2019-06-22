using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System;

namespace CursoUnitTesting.Business.SQLDataContext
{
    public class SQLDataContext : ISQLDataContext
    {
        private readonly SqlConnection _connection;
        public SQLDataContext()
        {
            var connectionString = @"Data Source=81.19.99.18,8005;Initial Catalog=CursoUnitTesting;Integrated Security=False;User Id=sa;Password=EverVLCis_123??2017;";
            _connection = CreateConnection(connectionString);
        }
        public IDataReader ExecuteReader(string commandText, ICollection<SqlParameter> parameters)
        {
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = commandText;
            if (parameters != null && parameters.Count != 0)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }
            var reader = cmd.ExecuteReader();
            return reader;
        }
        public int ExecuteNonQuery(string commandText, ICollection<SqlParameter> parameters)
        {
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = commandText;
            if (parameters != null && parameters.Count != 0)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }
            var result = cmd.ExecuteNonQuery();
            return result;
        }
        public void OpenConnection()
        {
            _connection.Open();
        }
        public void CloseConnection()
        {
            _connection.Close();
        }
        private SqlConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            return new SqlConnection(connectionString);
        }

    }
}
