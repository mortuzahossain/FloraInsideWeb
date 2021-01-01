using FloraWeb.Database;
using FloraWeb.Entity;
using FloraWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace FloraWeb.Repository
{
    public class EmergencyRepository
    {
        public CommonResponse GetAllEmergencyContact()
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Cont_EmergencyContacts");
            var emergencyContacts = new List<EmergencyContactViewModel>();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            EmergencyContactViewModel emergencyContact = new EmergencyContactViewModel()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim(),
                                Descriptions = dataTable.Rows[i]["Descriptions"].ToString().Trim(),
                                DisplayName = dataTable.Rows[i]["DisplayName"].ToString(),
                                ContactNumber = dataTable.Rows[i]["ContactNumber"].ToString().Trim(),

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
        public CommonResponse GetEmergencyContact(string id)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "Id", Value = id},
            };
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Cont_EmergencyContactsById", objects);
            EmergencyContactViewModel emergencyContact = new EmergencyContactViewModel();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            emergencyContact = new EmergencyContactViewModel()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Name = dataTable.Rows[i]["Name"].ToString().Trim(),
                                Descriptions = dataTable.Rows[i]["Descriptions"].ToString().Trim(),
                                DisplayName = dataTable.Rows[i]["DisplayName"].ToString(),
                                ContactNumber = dataTable.Rows[i]["ContactNumber"].ToString().Trim(),

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
        public CommonResponse AddEmergencyContact(EmergencyContactViewModel emergencyContact)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Name", Value = emergencyContact.Name},
                    new CommonKeyValueObject() {Key = "DisplayName", Value = emergencyContact.DisplayName},
                    new CommonKeyValueObject() {Key = "ContactNumber", Value = emergencyContact.ContactNumber},
                    new CommonKeyValueObject() {Key = "Descriptions", Value = emergencyContact.Descriptions}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_In_Cont_EmergencyContacts", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse UpdateEmergencyContact(EmergencyContactViewModel emergencyContact)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value =  emergencyContact.Id},
                    new CommonKeyValueObject() {Key = "Name", Value = emergencyContact.Name},
                    new CommonKeyValueObject() {Key = "DisplayName", Value = emergencyContact.DisplayName},
                    new CommonKeyValueObject() {Key = "ContactNumber", Value = emergencyContact.ContactNumber},
                    new CommonKeyValueObject() {Key = "Descriptions", Value = emergencyContact.Descriptions}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_Cont_EmergencyContacts", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
            }

            return commonResponse;
        }
        public CommonResponse DeactivateEmergencyContact(EmergencyContactViewModel emergencyContact)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value =  emergencyContact.Id}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_Cont_EmergencyContacts_Deactieve", objects);

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