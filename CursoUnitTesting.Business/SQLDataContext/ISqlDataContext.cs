

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CursoUnitTesting.Business.SQLDataContext
{
    public interface ISQLDataContext
    {
        IDataReader ExecuteReader(string sql, ICollection<SqlParameter> parameters);
        int ExecuteNonQuery(string sql, ICollection<SqlParameter> parameters);
        void OpenConnection();
        void CloseConnection();
    }
}
