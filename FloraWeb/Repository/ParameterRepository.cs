using FloraWeb.Database;
using FloraWeb.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FloraWeb.Repository
{
    public class ParameterRepository
    {
        #region Project
        public CommonResponse GetAllProject()
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Param_Project");
            var projects = new List<Project>();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            Project project = new Project()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim(),
                                Remarks = dataTable.Rows[i]["Remarks"].ToString().Trim()
                            };
                            projects.Add(project);
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = projects;

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
        public CommonResponse GetProjectById(string id)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance(); List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "Id", Value = id},
            };
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Param_ProjectById", objects);
            Project project = new Project();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            project = new Project()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim(),
                                Remarks = dataTable.Rows[i]["Remarks"].ToString().Trim()
                            };
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = project;

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
        public CommonResponse AddProject(Project project)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Name", Value = project.Name},
                    new CommonKeyValueObject() {Key = "Remarks", Value = project.Remarks}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_In_Param_Project", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse UpdateProject(Project project)
        {
            CommonResponse commonResponse = new CommonResponse();
            try
            {
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value =  project.Id},
                    new CommonKeyValueObject() {Key = "Name", Value = project.Name},
                    new CommonKeyValueObject() {Key = "Remarks", Value = project.Remarks}
                };
                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_Param_Project", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse DeleteProject(string id)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value = id}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_DL_Param_Project", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        #endregion


        #region Client Type
        public CommonResponse GetAllClientType()
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Param_ClientType");
            var clientTypes = new List<ClientType>();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            ClientType client = new ClientType()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim(),
                                Remarks = dataTable.Rows[i]["Remarks"].ToString().Trim()
                            };
                            clientTypes.Add(client);
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = clientTypes;

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
        public CommonResponse GetClientTypeById(string id)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance(); List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "Id", Value = id},
            };
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Param_ClientTypeById", objects);
            ClientType clientType = new ClientType();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            clientType = new ClientType()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim(),
                                Remarks = dataTable.Rows[i]["Remarks"].ToString().Trim()
                            };
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = clientType;

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
        public CommonResponse AddClientType(ClientType project)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Name", Value = project.Name},
                    new CommonKeyValueObject() {Key = "Remarks", Value = project.Remarks}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_In_Param_ClientType", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse UpdateClientType(ClientType project)
        {
            CommonResponse commonResponse = new CommonResponse();
            try
            {
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value =  project.Id},
                    new CommonKeyValueObject() {Key = "Name", Value = project.Name},
                    new CommonKeyValueObject() {Key = "Remarks", Value = project.Remarks}
                };
                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_Param_ClientType", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse DeleteClientType(string id)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value = id}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_DL_Param_ClientType", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        #endregion


        #region Client
        public CommonResponse GetAllClient()
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Param_Client");
            var clients = new List<Client>();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            Client client = new Client()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim(),
                                DisplayName = dataTable.Rows[i]["DisplayName"].ToString().Trim(),
                                ClientTypeId = dataTable.Rows[i]["ClientTypeId"].ToString().Trim(),
                                ClientName = dataTable.Rows[i]["ClientName"].ToString().Trim(),
                                Address = dataTable.Rows[i]["Address"].ToString().Trim(),
                                Lat = dataTable.Rows[i]["Lat"].ToString().Trim(),
                                Lan = dataTable.Rows[i]["Lan"].ToString().Trim(),
                                Status = dataTable.Rows[i]["Status"].ToString().Trim(),
                                ContactNo1 = dataTable.Rows[i]["ContactNo1"].ToString().Trim(),
                                ContactNo2 = dataTable.Rows[i]["ContactNo2"].ToString().Trim(),
                                Email = dataTable.Rows[i]["Email"].ToString().Trim(),
                                Website = dataTable.Rows[i]["Website"].ToString().Trim(),
                                Logo = dataTable.Rows[i]["Logo"].ToString().Trim(),
                                Details = dataTable.Rows[i]["Details"].ToString().Trim()
                            };
                            clients.Add(client);
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = clients;

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
        public CommonResponse GetClientById(string id)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance(); List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "Id", Value = id},
            };
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Param_ClientById", objects);
            Client client = new Client();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            client = new Client()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim(),
                                DisplayName = dataTable.Rows[i]["DisplayName"].ToString().Trim(),
                                ClientTypeId = dataTable.Rows[i]["ClientTypeId"].ToString().Trim(),
                                ClientName = dataTable.Rows[i]["ClientName"].ToString().Trim(),
                                Address = dataTable.Rows[i]["Address"].ToString().Trim(),
                                Lat = dataTable.Rows[i]["Lat"].ToString().Trim(),
                                Lan = dataTable.Rows[i]["Lan"].ToString().Trim(),
                                Status = dataTable.Rows[i]["Status"].ToString().Trim(),
                                ContactNo1 = dataTable.Rows[i]["ContactNo1"].ToString().Trim(),
                                ContactNo2 = dataTable.Rows[i]["ContactNo2"].ToString().Trim(),
                                Email = dataTable.Rows[i]["Email"].ToString().Trim(),
                                Website = dataTable.Rows[i]["Website"].ToString().Trim(),
                                Logo = dataTable.Rows[i]["Logo"].ToString().Trim(),
                                Details = dataTable.Rows[i]["Details"].ToString().Trim()
                            };
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = client;

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
        public CommonResponse AddClient(Client client)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Name", Value = client.Name},
                    new CommonKeyValueObject() {Key = "DisplayName", Value = client.DisplayName},
                    new CommonKeyValueObject() {Key = "ClientTypeId", Value = client.ClientTypeId},
                    new CommonKeyValueObject() {Key = "Address", Value = client.Address},
                    new CommonKeyValueObject() {Key = "Lat", Value = client.Lat},
                    new CommonKeyValueObject() {Key = "Lan", Value = client.Lan},
                    new CommonKeyValueObject() {Key = "Status", Value = client.Status},
                    new CommonKeyValueObject() {Key = "ContactNo1", Value = client.ContactNo1},
                    new CommonKeyValueObject() {Key = "ContactNo2", Value = client.ContactNo2},
                    new CommonKeyValueObject() {Key = "Email", Value = client.Email},
                    new CommonKeyValueObject() {Key = "Website", Value = client.Website},
                    new CommonKeyValueObject() {Key = "Logo", Value = client.Logo},
                    new CommonKeyValueObject() {Key = "Details", Value = client.Details}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_In_Param_Client", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse UpdateClient(Client client)
        {
            CommonResponse commonResponse = new CommonResponse();
            try
            {
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value = client.Id},
                    new CommonKeyValueObject() {Key = "Name", Value = client.Name},
                    new CommonKeyValueObject() {Key = "DisplayName", Value = client.DisplayName},
                    new CommonKeyValueObject() {Key = "ClientTypeId", Value = client.ClientTypeId},
                    new CommonKeyValueObject() {Key = "Address", Value = client.Address},
                    new CommonKeyValueObject() {Key = "Lat", Value = client.Lat},
                    new CommonKeyValueObject() {Key = "Lan", Value = client.Lan},
                    new CommonKeyValueObject() {Key = "Status", Value = client.Status},
                    new CommonKeyValueObject() {Key = "ContactNo1", Value = client.ContactNo1},
                    new CommonKeyValueObject() {Key = "ContactNo2", Value = client.ContactNo2},
                    new CommonKeyValueObject() {Key = "Email", Value = client.Email},
                    new CommonKeyValueObject() {Key = "Website", Value = client.Website},
                    new CommonKeyValueObject() {Key = "Logo", Value = client.Logo},
                    new CommonKeyValueObject() {Key = "Details", Value = client.Details}
                };
                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_Param_Client", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse DeleteClient(string id)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value = id}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_DL_Param_Client", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        #endregion


        #region JourneyBy
        public CommonResponse GetAllJourneyBy()
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Param_Param_JourneyBy");
            var journeyBies = new List<JourneyBy>();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            JourneyBy journeyBy = new JourneyBy()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim()
                            };
                            journeyBies.Add(journeyBy);
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = journeyBies;

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
        public CommonResponse GetJourneyById(string id)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance(); List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "Id", Value = id},
            };
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Param_Param_JourneyById", objects);
            JourneyBy project = new JourneyBy();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            project = new JourneyBy()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim()
                            };
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = project;

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
        public CommonResponse AddJourneyBy(JourneyBy project)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Name", Value = project.Name}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_In_Param_JourneyBy", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse UpdateJourneyBy(JourneyBy project)
        {
            CommonResponse commonResponse = new CommonResponse();
            try
            {
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value =  project.Id},
                    new CommonKeyValueObject() {Key = "Name", Value = project.Name}
                };
                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_Param_JourneyBy", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse DeleteJourneyBy(string id)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value = id}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_DL_Param_JourneyBy", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        #endregion


        #region UserGroup
        public CommonResponse GetAllUserGroup()
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Param_UserGroup");
            var journeyBies = new List<UserGroup>();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            UserGroup journeyBy = new UserGroup()
                            {
                                Id = (int)dataTable.Rows[i]["Id"],
                                Name = dataTable.Rows[i]["Name"].ToString().Trim()
                            };
                            journeyBies.Add(journeyBy);
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = journeyBies;

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
        public CommonResponse GetUserGroup(string id)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance(); List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "Id", Value = id},
            };
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Param_UserGroupById", objects);
            UserGroup project = new UserGroup();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            project = new UserGroup()
                            {
                                Id = (int)dataTable.Rows[i]["Id"],
                                Name = dataTable.Rows[i]["Name"].ToString().Trim()
                            };
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = project;

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
        public CommonResponse AddUserGroup(UserGroup project)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Name", Value = project.Name}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_In_Param_UserGroup", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse UpdateUserGroup(UserGroup project)
        {
            CommonResponse commonResponse = new CommonResponse();
            try
            {
                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value =  project.Id.ToString()},
                    new CommonKeyValueObject() {Key = "Name", Value = project.Name}
                };
                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_Param_UserGroup", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse DeleteUserGroup(string id)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value = id}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_DL_Param_UserGroup", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        #endregion


    }
}