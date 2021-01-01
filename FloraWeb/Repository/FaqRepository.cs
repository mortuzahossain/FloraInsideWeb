using FloraWeb.Database;
using FloraWeb.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace FloraWeb.Repository
{
    public class FaqRepository
    {
        public CommonResponse GetAllFaq()
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Faqs");
            var emergencyContacts = new List<Faq>();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            Faq emergencyContact = new Faq()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Title = dataTable.Rows[i]["Name"].ToString().Trim(),
                                Description = dataTable.Rows[i]["Description"].ToString().Trim(),
                                ProjectId = dataTable.Rows[i]["ProjectId"].ToString(),
                                DownVote = dataTable.Rows[i]["DownVote"].ToString().Trim(),
                                UpVote = dataTable.Rows[i]["UpVote"].ToString().Trim(),
                                Status = dataTable.Rows[i]["Status"].ToString().Trim(),
                                ProjectName = dataTable.Rows[i]["ProjectName"].ToString().Trim()
                            };
                            emergencyContacts.Add(emergencyContact);
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = emergencyContacts;

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
        public CommonResponse GetFaqById(string id)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "Id", Value = id},
            };
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_FaqById", objects);
            Faq emergencyContact = new Faq();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            emergencyContact = new Faq()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Title = dataTable.Rows[i]["Name"].ToString().Trim(),
                                Description = dataTable.Rows[i]["Description"].ToString().Trim(),
                                ProjectId = dataTable.Rows[i]["ProjectId"].ToString(),
                                DownVote = dataTable.Rows[i]["DownVote"].ToString().Trim(),
                                UpVote = dataTable.Rows[i]["UpVote"].ToString().Trim(),
                                Status = dataTable.Rows[i]["Status"].ToString().Trim(),
                                ProjectName = dataTable.Rows[i]["ProjectName"].ToString().Trim()

                            };
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = emergencyContact;

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
        public CommonResponse AddFaq(Faq faq)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Title", Value = faq.Title},
                    new CommonKeyValueObject() {Key = "Description", Value = faq.Description},
                    new CommonKeyValueObject() {Key = "ProjectId", Value = faq.ProjectId}
                };
                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_In_Faqs", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse UpdateFaq(Faq faq)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value =  faq.Id},
                    new CommonKeyValueObject() {Key = "Title", Value = faq.Title},
                    new CommonKeyValueObject() {Key = "Description", Value = faq.Description},
                    new CommonKeyValueObject() {Key = "ProjectId", Value = faq.ProjectId}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_Faqs", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse DeleteFaq(string id)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value =  id}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_DL_Faqs", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse UpdateFaqVote(string id,string vote)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value =  id},
                    new CommonKeyValueObject() {Key = "UpVote", Value = vote} // 1 for upvote others for downvote
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_FaqVote", objects); 

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