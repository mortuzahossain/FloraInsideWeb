using FloraWeb.Database;
using FloraWeb.Entity;
using FloraWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FloraWeb.Repository
{
    public class UsersRepository
    {
        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }

            return Convert.ToBase64String(hashBytes);
        }

        public CommonResponse UsersLogin(LoginViewModel loginViewModel)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "LoginId", Value = loginViewModel.LoginId},
                new CommonKeyValueObject() {Key = "Password", Value = Hash(loginViewModel.Password)},
            };

            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_User_By_Email", objects);

            UserLogin userLogin = null;
            
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            userLogin = new UserLogin()
                            {
                                UserId = dataTable.Rows[i]["UserId"].ToString().Trim(),
                                LoginId = dataTable.Rows[i]["LoginId"].ToString().Trim(),
                                LoginName = dataTable.Rows[i]["LoginName"].ToString().Trim(),
                                UserGroupName = dataTable.Rows[i]["UserGroupName"].ToString().Trim(),
                                UserGroupId = dataTable.Rows[i]["UserGroupId"].ToString().Trim()
                            };
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = userLogin;

                    }
                    else
                    {
                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseFailed;

                    }
                }
                else
                {
                    commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                    commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseFailed;
                }
            }
            catch (Exception ex)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = ex.Message;
            }

            return commonResponse;
        }



    }
}