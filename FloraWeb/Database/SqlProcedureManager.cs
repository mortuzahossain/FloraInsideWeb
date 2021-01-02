using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FloraWeb.Entity;

namespace FloraWeb.Database
{
    public class SqlProcedureManager
    {
        private SqlProcedureManager()
        {

        }

        private static SqlProcedureManager _sqlManager;

        public static SqlProcedureManager Instance()
        {
            return _sqlManager ?? (_sqlManager = new SqlProcedureManager());
        }

        public CommonResponse ExecuteNonSpQuery(string spName, List<CommonKeyValueObject> objects)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {
                using (SqlConnection _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_CONNECTION"].ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand(spName, _cnn) { CommandType = CommandType.StoredProcedure };
                    foreach (var o in objects)
                    {
                        cmd.Parameters.AddWithValue(o.Key, o.Value);
                    }

                    _cnn.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                    {
                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseUserMsg = Constants.ResponseMsg.ResponseSuccess;
                    }
                    else
                    {
                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseFailed;
                        commonResponse.ResponseUserMsg = Constants.ResponseMsg.ResponseFailed;
                    }
                    _cnn.Close();
                }
            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
                commonResponse.ResponseUserMsg = Constants.ResponseMsg.ResponseFailed;
            }

            return commonResponse;
        }

        public DataTable ExecuteSpGetDataTable(string spName, List<CommonKeyValueObject> objects = null)
        {
            using (SqlConnection _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_CONNECTION"].ConnectionString))
            {

                DataTable dataTable = new DataTable();
                try
                {
                    _cnn.Open();
                    SqlCommand cmd = new SqlCommand(spName, _cnn) { CommandType = CommandType.StoredProcedure };
                    if (objects != null)
                    {

                        foreach (var o in objects)
                        {
                            cmd.Parameters.AddWithValue(o.Key, o.Value);
                        }
                    }

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dataTable);
                    _cnn.Close();
                }
                catch
                {
                }

                return dataTable;
            }
        }
    }
}