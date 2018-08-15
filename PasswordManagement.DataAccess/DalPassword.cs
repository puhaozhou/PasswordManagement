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
            var sql = @"SELECT PKID as ID, site_name as SiteName, SITE_PASSWORD as SitePassword FROM SITE_DATE WHERE ISDELETED <> 0 and USERID = @UserID";
            var dt = new DataTable();
            using (var conn = GetSQLiteConnection("SqlDiagnosticsDb"))
            {
                result = conn.Query<SiteModel>(sql, new { USERID = "1" }).ToList();
            }
            return result;
        }

        public static bool UpdateSiteInfo(string columnName, string value)
        {
            var result = false;
            var sql = $"UPDATE SITE_DATE SET {columnName} = @SiteData where USERID = @UserId";
            using (var conn = GetSQLiteConnection("SqlDiagnosticsDb"))
            {
                var data = conn.Execute(sql, new { SiteData = value, UserId = '1'});
                result = data > 0;
            }
            return result;
        }

        public static bool InsertSiteInfo()
        {
            return true;
        }
    }
}
