using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FloraWeb.Entity;

namespace FloraWeb.Database
{
    public class SqlQueryManager
    {
        private SqlQueryManager()
        {

        }

        private static SqlQueryManager _sqlManager;
        public static SqlQueryManager Instance()
        {
            return _sqlManager ?? (_sqlManager = new SqlQueryManager());
        }

        public CommonResponse ExecuteNonQuery(string sqlQuery)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {
                using (SqlConnection _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_CONNECTION"].ConnectionString))
                {
                    _cnn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter { InsertCommand = new SqlCommand(sqlQuery, _cnn) };
                    int k = adapter.InsertCommand.ExecuteNonQuery();
                    _cnn.Close();
                    if (k != 0)
                    {
                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                    }
                    else
                    {
                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseFailed;
                    }
                }
            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }


            return commonResponse;
        }

        public DataTable ExecuteQueryGetDataTable(string sqlQuery)
        {
            using (SqlConnection _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_CONNECTION"].ConnectionString))
            {
                _cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, _cnn);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                _cnn.Close();
                return dataTable;
            }
        }

        public string ExecuteQueryGetSingleString(string sqlQuery)
        {
            using (SqlConnection _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_CONNECTION"].ConnectionString))
            {
                _cnn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, _cnn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                string value = "";
                while (reader.Read())
                {
                    value = reader.GetValue(0).ToString();
                }
                reader.Close();
                sqlCommand.Dispose();
                _cnn.Close();
                return value;
            }
        }
    }
}