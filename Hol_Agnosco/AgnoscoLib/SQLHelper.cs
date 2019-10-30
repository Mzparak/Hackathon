using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System;
namespace Agnoscolib
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

        public static SqlParameter NewBitParam(string name, bool value)
        {
            try
            {
                return SQLDAO.NewBitParam(name, value);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public static SqlParameter NewFloatParam(string name, float value)
        {
            try
            {
                return SQLDAO.NewFloatParam(name, value);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public static SqlParameter NewDateParam(string name, DateTime value)
        {
            try
            {
                if (value == DateTime.MinValue)
                {
                    return SQLDAO.NewNullParam(name);
                }
                else
                {
                    return SQLDAO.NewDateParam(name, value);
                }
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public static SqlParameter NewNullParam(string name)
        {
            try
            {
                return SQLDAO.NewNullParam(name);

            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public static SqlParameter NewIntParam(string name, int value)
        {
            try
            {
                return SQLDAO.NewIntParam(name, value);
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

        #region ExecuteQuery helpers
        #region ....ExecuteQuery
        public static void ExecuteQuery(SqlConnection sqlConnection, string spName)
        {
            SQLHelper.ExecuteQuery(sqlConnection, spName, null);
        }

        public static void ExecuteQuery(SqlConnection sqlConnection, string spName, params SqlParameter[] sqlParams)
        {
            SqlCommand cmd = null;


            try
            {
                cmd = SQLHelper.NewCommand(sqlConnection, spName, sqlParams);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if ((ex.Number == -2) || (ex.Number == 844) || (ex.Number == 845))          //SQL TIMEOUT - http://msdn.microsoft.com/en-us/library/aa937592%28SQL.80%29.aspx
                {
                    ////Log timeout
                    //Log.Error( spName + " timed out..." + SQL.ParamsAsString(sqlParams), ex);

                }

                if (ex.Number == 2812)              //MISSING SP/OBJECT
                {
                    ////Log timeout
                    //Log.Error(spName + " is missing..." + SQL.ParamsAsString(sqlParams), ex);
                    //FIX! create and use MF.Lib.ChangeManagement.AddDeploymentProblem() :)
                    //MF.Lib.SPTimeouts.DAL.AddSPTimeouts(MF.Lib.SPTimeouts.DBType.SQL, spName, SQL.ParamsAsString(sqlParams));	
                }

                throw ex;
            }
            catch (Exception ex)
            {
                //Log.Error( "Exception : " + SQL.ParamsAsString(sqlParams), ex);
                throw ex;
            }
            finally
            {
                cmd = null;
            }
        }
        #endregion
        #endregion







    }
}