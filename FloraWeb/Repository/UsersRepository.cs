using FloraWeb.Database;
using FloraWeb.Entity;
using FloraWeb.Models;
using FloraWeb.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FloraWeb.Repository
{
    public class UsersRepository
    {
        public CommonResponse UsersLogin(LoginViewModel loginViewModel)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "LoginId", Value = loginViewModel.LoginId},
                new CommonKeyValueObject() {Key = "Password", Value = SecurityUtility.Hash(loginViewModel.Password)},
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

        public CommonResponse AddUsers(UserViewModel userLogin)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                // Generate Password

                string passwordPlain = SecurityUtility.RandomString(8);
                string password = SecurityUtility.Hash(passwordPlain);
                

                // Save User Into database
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Email", Value = userLogin.Email},
                    new CommonKeyValueObject() {Key = "LoginName", Value = userLogin.LoginName},
                    new CommonKeyValueObject() {Key = "LoginId", Value = userLogin.LoginId},
                    new CommonKeyValueObject() {Key = "UserGroupId", Value = userLogin.UserGroupId},
                    new CommonKeyValueObject() {Key = "Password", Value = password}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_In_UserLogin", objects);


                // Send password using email
                if(commonResponse.ResponseCode == Constants.ResponseCode.ResponseSuccess)
                {
                    string subject = "Flora Inside Login Credentials";
                    string content = "Dear [name],"+Environment.NewLine+ "Welcome to Flora Systems Ltd.Your login credential:" + Environment.NewLine + "Login Id: [loginid]" + Environment.NewLine + "Password: [password]" + Environment.NewLine + "Regards" + Environment.NewLine + "Flora Systems ltd";
                    content = content.Replace("[name]", userLogin.LoginName);
                    content = content.Replace("[loginid]", userLogin.LoginId);
                    content = content.Replace("[password]", passwordPlain);
                    GeneralUtility.SendMail(userLogin.Email, subject, content);
                }


            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }

    }
}