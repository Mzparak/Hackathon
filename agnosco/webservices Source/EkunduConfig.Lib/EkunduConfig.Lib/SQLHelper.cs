using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System;
namespace EkunduConfig
{

    /// <summary>
    /// SqlDataAccess is being used for accessing MSSQL database quickly and easily. 
    /// Requires a connection string that is named MsSql defined on web.config file. This connection string is used as default. 
    /// For using different connection strings you should pass the name of the connection string as a parameter with methods.
    /// </summary>
    public class SQLHelper
    {
        #region set Connection String
        public const string CONNECTION_STRING_NAME = "DEV_EKUNDU";
        private static string _connectionString = string.Empty;
        public static string ConnectionString
        {
            get
            {
                if (_connectionString == string.Empty)
                {
                    _connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
                }
                return _connectionString;
            }
        }
        #endregion

        #region connection helpers
        #region ....NewConnection
        public static SqlConnection NewConnection(string connectionString)
        {
            return SQLHelper.NewConnection(connectionString, false);
        }

        public static SqlConnection NewConnection(string connectionString, bool returnClosedConnection)
        {
            SqlConnection result = null;

            try
            {
                result = SQLDAO.NewConnection(connectionString, returnClosedConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        #endregion

        #region ....CloseConnection
        public static void CloseConnection(SqlConnection sqlConnection)
        {
            try
            {
                SQLDAO.CloseConnection(sqlConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region ....IsOpen
        public static bool IsOpen(SqlConnection sqlConnection)
        {
            bool result = false;

            try
            {
                result = SQLDAO.IsOpen(sqlConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static bool IsOpen(DataSet dataSet)
        {
            bool result = false;

            try
            {
                result = SQLDAO.IsOpen(dataSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static bool IsOpen(SqlDataReader dataReader)
        {
            bool result = false;

            try
            {
                result = SQLDAO.IsOpen(dataReader);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        #endregion

        #region ...command Helpers
        #region ....NewCommand
        public static SqlCommand NewCommand(SqlConnection sqlConnection)
        {
            return SQLHelper.NewCommand(sqlConnection, null, null);
        }

        public static SqlCommand NewCommand(SqlConnection sqlConnection, string spName)
        {
            return SQLHelper.NewCommand(sqlConnection, spName, null);
        }

        public static SqlCommand NewCommand(SqlConnection sqlConnection, string spName, params SqlParameter[] sqlParams)
        {
            SqlCommand result = null;

            try
            {
                result = SQLDAO.NewCommand(sqlConnection, spName, sqlParams);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }
        #endregion
        #endregion

        #region ...parameters Helpers
        public static SqlParameter NewVarcharParam(string name, int size, string value)
        {
            try
            {
                return SQLDAO.NewVarcharParam(name, size, value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        public static DataSet GetDataSet(SqlConnection sqlConnection, string spName, params SqlParameter[] sqlParams)
        {
            DataSet result = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = SQLHelper.NewCommand(sqlConnection, spName, sqlParams);

                result = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(result);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd = null;
            }

            return result;
        }







    }
}