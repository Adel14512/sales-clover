using Dapper;
using Evaluation.CAL;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Evaluation.DAL.Dapper
{
    internal static class DapperDbAccess
    {
        private static string connString = string.Empty;
        private static string connStringV2 = string.Empty;
        internal static List<T> Query<T>(string commandName, object param, CommandType cmdType)
        {
            //IEnumerable<T> multipleResult;
            connString = Global.ConnString;
            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                //multipleResult = param != null
                //    ? db.Query<T>(commandName, param, commandType: cmdType)
                //    : db.Query<T>(commandName, null, commandType: cmdType);
                return db.Query<T>(commandName, param, commandType: cmdType).ToList();
            }

            //return multipleResult.ToList();
        }

        internal static List<T> QueryV2<T>(string commandName, object param, CommandType cmdType)
        {
            //IEnumerable<T> multipleResult;
            connStringV2 = Global.ConnStringV2;
            using (IDbConnection db = new SqlConnection(connStringV2))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                //multipleResult = param != null
                //    ? db.Query<T>(commandName, param, commandType: cmdType)
                //    : db.Query<T>(commandName, null, commandType: cmdType);
                return db.Query<T>(commandName, param, commandType: cmdType).ToList();
            }

            //return multipleResult.ToList();
        }

        internal static List<dynamic> QueryDynamic<dynamic>(string commandName, object param, CommandType cmdType)
        {
            //IEnumerable<T> multipleResult;
            connString = Global.ConnString;
            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                //multipleResult = param != null
                //    ? db.Query<T>(commandName, param, commandType: cmdType)
                //    : db.Query<T>(commandName, null, commandType: cmdType);
                return db.Query<dynamic>(commandName, param, commandType: cmdType).ToList();
            }

            //return multipleResult.ToList();
        }

        internal static T QueryFirst<T>(string commandName, object param, CommandType cmdType)
        {
            connString = Global.ConnString;
            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                return db.QueryFirst<T>(commandName, param, commandType: cmdType);
            }
        }

        internal static T QueryFirstOrDefault<T>(string commandName, object param, CommandType cmdType)
        {
            connString = Global.ConnString;
            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                return db.QueryFirstOrDefault<T>(commandName, param, commandType: cmdType);
            }
        }

        internal static T QuerySingle<T>(string commandName, object param, CommandType cmdType)
        {
            connString = Global.ConnString;
            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                return db.QuerySingle<T>(commandName, param, commandType: cmdType);
            }
        }

        internal static T QuerySingleOrDefault<T>(string commandName, object param, CommandType cmdType)
        {
            connString = Global.ConnString;
            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                return db.QuerySingleOrDefault<T>(commandName, param, commandType: cmdType);
            }
        }

        internal static List<T> QueryMultiple<T>(string commandName, object param, CommandType cmdType)
        {
            //IEnumerable<T> multipleResult;
            connString = Global.ConnString;
            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                //multipleResult = param != null
                //    ? db.Query<T>(commandName, param, commandType: cmdType)
                //    : db.Query<T>(commandName, null, commandType: cmdType);
                return db.Query<T>(commandName, param, commandType: cmdType).ToList();
            }

            //return multipleResult.ToList();
        }
    }
}
