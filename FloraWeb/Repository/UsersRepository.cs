using FloraWeb.Database;
using FloraWeb.Entity;
using FloraWeb.Models;
using FloraWeb.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                        commonResponse.ResponseUserMsg = Constants.ResponseMsg.ResponseLoginSuccess;
                        commonResponse.ResponseData = userLogin;

                    }
                    else
                    {
                        commonResponse.ResponseUserMsg = Constants.ResponseMsg.ResponseLoginFailed;
                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseFailed;

                    }
                }
                else
                {
                    commonResponse.ResponseUserMsg = Constants.ResponseMsg.ResponseLoginFailed;
                    commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                    commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseFailed;
                }
            }
            catch (Exception ex)
            {
                commonResponse.ResponseUserMsg = Constants.ResponseMsg.ResponseLoginFailed;
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
        public CommonResponse GetUserProfile(UserProfile userProfile)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "UserId", Value = userProfile.UserId}
            };

            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_UserProfile_By_UserId", objects);

            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            userProfile = new UserProfile()
                            {
                                UserId = dataTable.Rows[i]["UserId"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim(),
                                Email = dataTable.Rows[i]["Email"].ToString().Trim(),
                                Phone = dataTable.Rows[i]["Phone"].ToString().Trim(),
                                BloodGroup = dataTable.Rows[i]["BloodGroup"].ToString().Trim(),
                                MaritialStatus = dataTable.Rows[i]["MaritialStatus"].ToString().Trim(),
                                Designation = dataTable.Rows[i]["Designation"].ToString().Trim(),
                                Department = dataTable.Rows[i]["Department"].ToString().Trim(),
                                PresentAddress = dataTable.Rows[i]["PresentAddress"].ToString().Trim(),
                                EmergencyContact = dataTable.Rows[i]["EmergencyContact"].ToString().Trim(),
                                Image = dataTable.Rows[i]["Image"].ToString().Trim(),
                                PermanentAddress = dataTable.Rows[i]["PermanentAddress"].ToString().Trim(),
                                Status = dataTable.Rows[i]["Status"].ToString().Trim(),
                                JoiningDate = dataTable.Rows[i]["JoiningDate"].ToString().Trim(),
                                FireId = dataTable.Rows[i]["FireId"].ToString().Trim(),
                                Nid = dataTable.Rows[i]["Nid"].ToString().Trim(),
                                AccountStatus = dataTable.Rows[i]["AccountStatus"].ToString().Trim(),
                            };
                        }


                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = userProfile;

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
        public CommonResponse UpdateUsersProfile(UserProfile userProfile)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "UserId", Value =  userProfile.UserId},
                    new CommonKeyValueObject() {Key = "Name", Value = userProfile.Name},
                    new CommonKeyValueObject() {Key = "Email", Value = userProfile.Email},
                    new CommonKeyValueObject() {Key = "ContactNumber", Value = userProfile.Phone},
                    new CommonKeyValueObject() {Key = "BloodGroup", Value = userProfile.BloodGroup},
                    new CommonKeyValueObject() {Key = "MaritialStatus", Value = userProfile.MaritialStatus},
                    new CommonKeyValueObject() {Key = "Department", Value = userProfile.Department},
                    new CommonKeyValueObject() {Key = "PresentAddress", Value = userProfile.PresentAddress},
                    new CommonKeyValueObject() {Key = "PermanentAddress", Value = userProfile.PermanentAddress},
                    new CommonKeyValueObject() {Key = "EmergencyContact", Value = userProfile.EmergencyContact},
                    new CommonKeyValueObject() {Key = "Status", Value = userProfile.Status},
                    new CommonKeyValueObject() {Key = "JoiningDate", Value = userProfile.JoiningDate},
                    new CommonKeyValueObject() {Key = "FireId", Value = userProfile.FireId},
                    new CommonKeyValueObject() {Key = "Nid", Value = userProfile.Nid},
                    new CommonKeyValueObject() {Key = "AccountStatus", Value = userProfile.AccountStatus}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_UserProfile", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse UpdateUsersPassword(string userId,string password)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "UserId", Value =  userId},
                    new CommonKeyValueObject() {Key = "Password", Value = SecurityUtility.Hash(password)}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_UserPasswordById", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse ForgetPassword(string email)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {
                string password = SecurityUtility.RandomString(8);
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Email", Value =  email},
                    new CommonKeyValueObject() {Key = "Password", Value = SecurityUtility.Hash(password)}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_UserPasswordByEmail", objects);
                string subject = "Flora Inside Password Change";
                string content = "Dear sir/mam," + Environment.NewLine + "Welcome to Flora Systems Ltd."+ Environment.NewLine + "Your new Password: [password]" + Environment.NewLine+ "Regards" + Environment.NewLine + "Flora Systems ltd";
                content = content.Replace("[password]", password);
                GeneralUtility.SendMail(email, subject, content);
            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse UpdateUsersProfileImage(UserProfile userProfile)
        {
            CommonResponse commonResponse = new CommonResponse();
            commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
            commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseFailed;
            commonResponse.ResponseUserMsg = Constants.ResponseMsg.ResponseUserMsgFailed;

            try
            {

                string path = System.Web.HttpContext.Current.Server.MapPath("~/ImageStorage/ProfilePics");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filename = DateTime.Now.Ticks + ".Png";
                if (!GeneralUtility.SaveByteArrayAsImage(filename, userProfile.Image))
                {
                    return commonResponse;
                }



                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "UserId", Value =  userProfile.UserId},
                    new CommonKeyValueObject() {Key = "Image", Value = filename}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_UserProfileImage", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse GetAllUserProfileForContactBook()
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_AllUserProfile_For_contactbook");
            var userProfiles = new List<UserProfile>();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            UserProfile userProfile = new UserProfile()
                            {
                                UserId = dataTable.Rows[i]["UserId"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim(),
                                Email = dataTable.Rows[i]["Email"].ToString().Trim(),
                                Phone = dataTable.Rows[i]["Phone"].ToString().Trim(),
                                BloodGroup = dataTable.Rows[i]["BloodGroup"].ToString().Trim(),
                                MaritialStatus = dataTable.Rows[i]["MaritialStatus"].ToString().Trim(),
                                Designation = dataTable.Rows[i]["Designation"].ToString().Trim(),
                                Department = dataTable.Rows[i]["Department"].ToString().Trim(),
                                PresentAddress = dataTable.Rows[i]["PresentAddress"].ToString().Trim(),
                                EmergencyContact = dataTable.Rows[i]["EmergencyContact"].ToString().Trim(),
                                Image = dataTable.Rows[i]["Image"].ToString().Trim(),
                                PermanentAddress = dataTable.Rows[i]["PermanentAddress"].ToString().Trim(),
                                Status = dataTable.Rows[i]["Status"].ToString().Trim(),
                                JoiningDate = dataTable.Rows[i]["JoiningDate"].ToString().Trim(),
                                FireId = dataTable.Rows[i]["FireId"].ToString().Trim(),
                                Nid = dataTable.Rows[i]["Nid"].ToString().Trim(),
                                AccountStatus = dataTable.Rows[i]["AccountStatus"].ToString().Trim(),
                            };
                            userProfiles.Add(userProfile);
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = userProfiles;

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