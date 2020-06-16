using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;

namespace DataLibraryOne.DataAccess
{
    public static class SqlDataAccess // warstwa dostępu do naszej bazy danych wszystkie repozytoria będą jej używały
    {
        public static string GetConnectionString(string connectionName = "DefaultConnection")
        {

            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var data = cnn.Query<T>(sql).ToList();
                return data;
            }
        }

        public static T LoadData<T>(string sql,object parameters)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var data = cnn.Query<T>(sql, parameters).SingleOrDefault();
                return data;          
            }
        }

        public static int SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                 {

                //  cmd.Connection = cnn;
                //  cnn.Open();
                // return cmd.ExecuteNonQuery();
                return cnn.Execute(sql, parameters);
            }

        }
    }
}
