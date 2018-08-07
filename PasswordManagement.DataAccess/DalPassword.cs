using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using PasswordManagement.DataAccess.Entity;
using Dapper;
using System.Data.SQLite;

namespace PasswordManagement.DataAccess
{
    public static class DalPassword
    {
        public static IDbConnection GetSQLiteConnection(string connName)
        {
            IDbConnection result = new SQLiteConnection();
            try
            {            
                var connStr = ConfigurationManager.ConnectionStrings[connName].ConnectionString;
                if (!string.IsNullOrWhiteSpace(connStr))
                {
                    result = new SQLiteConnection(connStr);
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static List<SiteModel> GetPasswordImformation()
        {
            var result = new List<SiteModel>();
            var sql = @"SELECT SITE_NAME, SITE_PASSWORD FROM SITE_DATE WHERE ISDELETED <> 0 and USERID = @UserID";
            var dt = new DataTable();
            using (var conn = GetSQLiteConnection("SqlDiagnosticsDb"))
            {
                result = conn.Query<SiteModel>(sql, new { USERID = "1" }).ToList();
            }
            return result;
        }
    }
}
