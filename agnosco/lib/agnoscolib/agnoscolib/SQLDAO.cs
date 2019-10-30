using System.Data;
using System.Data.SqlClient;
using System;

namespace agnoscolib
{
    public class SQLDAO
    {
        #region command helpers
        public static SqlCommand NewCommand(SqlConnection sqlConnection)
        {
            return SQLDAO.NewCommand(sqlConnection, null, null);
        }

        public static SqlCommand NewCommand(SqlConnection sqlConnection, string spName)
        {
            return SQLDAO.NewCommand(sqlConnection, spName, null);
        }

        public static SqlCommand NewCommand(SqlConnection sqlConnection, string spName, params SqlParameter[] sqlParams)
        {
            SqlCommand result = null;

            try
            {
                if (!SQLDAO.IsOpen(sqlConnection))
                {
                    throw new Exception("Null or closed connection");
                }

                result = new SqlCommand();
                result.Connection = sqlConnection;
                result.CommandType = CommandType.StoredProcedure;

                if ((spName != null) && (spName.Trim().Length > 0))
                {
                    result.CommandText = spName;
                }

                if ((sqlParams != null) && (sqlParams.Length > 0))
                {
                    foreach (SqlParameter p in sqlParams)
                    {
                        result.Parameters.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        #endregion

        #region connection helpers
        public static SqlConnection NewConnection(string connectionString)
        {
            return SQLDAO.NewConnection(connectionString, false);
        }

        public static SqlConnection NewConnection(string connectionString, bool returnClosedConnection)
        {
            SqlConnection result = null;

            try
            {
                result = new SqlConnection();
                result.ConnectionString = connectionString;

                if (!returnClosedConnection)
                {
                    result.Open();
                    if (!SQLDAO.IsOpen(result))
                    {
                        throw new Exception("Failed to open connection");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static void CloseConnection(SqlConnection sqlConnection)
        {
            try
            {
                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection = null;
            }
        }
        #endregion

        #region validation helpers
        public static bool IsOpen(SqlConnection sqlConnection)
        {
            bool result = false;

            try
            {
                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        result = true;
                    }
                }
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
                if (dataSet != null)
                {
                    if ((dataSet.Tables != null) && (dataSet.Tables.Count > 0))
                    {
                        //empty/zero-row dataset is open!!!
                        //if ( (dataSet.Tables[0].Rows != null) && (dataSet.Tables[0].Rows.Count > 0) )
                        //{
                        result = true;
                        //}
                    }
                }
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
                if (dataReader != null)
                {
                    if (!dataReader.IsClosed)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        #endregion


        #region parameter helpers
        public static SqlParameter NewVarcharParam(string name, int size, string value)
        {
            try
            {
                SqlParameter result = new SqlParameter(name, SqlDbType.VarChar, size);
                if (value == null)
                {
                    result.Value = DBNull.Value;
                }
                else
                {
                    result.Value = value;
                }

                return result;
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
                SqlParameter result = new SqlParameter(name, SqlDbType.Bit);
                result.Value = value;
                return result;
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
                SqlParameter result = new SqlParameter(name, SqlDbType.Float);
                result.Value = value;
                return result;
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
                    value = Convert.ToDateTime(1 / 1 / 1753);
                }
                SqlParameter result = new SqlParameter(name, SqlDbType.DateTime);
                result.Value = value;
                return result;
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
                SqlParameter result = new SqlParameter(name, DBNull.Value);
                return result;
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
                SqlParameter result = new SqlParameter(name, SqlDbType.Int);
                result.Value = value;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    #endregion


        #region ExecuteQuery helpers
        public static void ExecuteQuery(SqlConnection sqlConnection, string spName)
        {
            SQLDAO.ExecuteQuery(sqlConnection, spName, null);
        }

        public static void ExecuteQuery(SqlConnection sqlConnection, string spName, params SqlParameter[] sqlParams)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = SQLDAO.NewCommand(sqlConnection, spName, sqlParams);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd = null;
            }
        }
        #endregion
    }

}
