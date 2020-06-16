using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Data.Common;
using System.Configuration;

namespace DataLibrary.DataAccess
{
  public static class SqlDataAcces // warstwa dostępu do naszej bazy danych wszystkie repozytoria będą jej używały
    {
        public static string GetConnectionString(string connectionName = "aspnet-Api-20200611111032")
        {

            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
