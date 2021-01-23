using FloraWeb.Database;
using FloraWeb.Entity;
using FloraWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace FloraWeb.Repository
{
    public class ConvinceBillRepository
    {
        public CommonResponse AddTourInRegister(TourRegister tourRegister)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "UserId", Value = tourRegister.UserId},
                    new CommonKeyValueObject() {Key = "TDate", Value = tourRegister.TDate},
                    new CommonKeyValueObject() {Key = "ToAddress", Value = tourRegister.ToAddress},
                    new CommonKeyValueObject() {Key = "FromAddress", Value = tourRegister.FromAddress},
                    new CommonKeyValueObject() {Key = "JourneyBy", Value = tourRegister.JourneyBy},
                    new CommonKeyValueObject() {Key = "Fare", Value = tourRegister.Fare},
                    new CommonKeyValueObject() {Key = "Remarks", Value = tourRegister.Remarks},
                    new CommonKeyValueObject() {Key = "Lat", Value = tourRegister.Lat},
                    new CommonKeyValueObject() {Key = "Lan", Value = tourRegister.Lan},
                    new CommonKeyValueObject() {Key = "UpOrDown", Value = tourRegister.UpOrDown},
                    new CommonKeyValueObject() {Key = "TerminalId", Value = tourRegister.TerminalId},
                    new CommonKeyValueObject() {Key = "ClientId", Value = tourRegister.ClientId},
                    new CommonKeyValueObject() {Key = "IssueId", Value = tourRegister.IssueId}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_In_Conv_TourRegister", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
                commonResponse.ResponseUserMsg = "Unable to upload Convince.";
            }

            return commonResponse;
        }

        public CommonResponse GetTourFromRegisterByUserId(string userId)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "UserId", Value = userId},
            };
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Conv_TourRegister_ById", objects);
            var tourRegisters = new List<TourRegister>();
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            TourRegister tourRegister = new TourRegister()
                            {
                                UserId = dataTable.Rows[i]["UserId"].ToString().Trim(),
                                ClientId = dataTable.Rows[i]["ClientId"].ToString().Trim(),
                                Fare = dataTable.Rows[i]["Fare"].ToString().Trim(),
                                FromAddress = dataTable.Rows[i]["FromAddress"].ToString().Trim(),
                                ToAddress = dataTable.Rows[i]["ToAddress"].ToString().Trim(),
                                JourneyBy = dataTable.Rows[i]["JourneyBy"].ToString().Trim(),
                                IssueId = dataTable.Rows[i]["IssueId"].ToString().Trim(),
                                Lan = dataTable.Rows[i]["Lan"].ToString().Trim(),
                                Lat = dataTable.Rows[i]["Lat"].ToString().Trim(),
                                Remarks = dataTable.Rows[i]["Remarks"].ToString().Trim(),
                                TDate = dataTable.Rows[i]["TDate"].ToString().Trim(),
                                UpOrDown = dataTable.Rows[i]["UpOrDown"].ToString().Trim()
                            };
                            tourRegisters.Add(tourRegister);
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = tourRegisters;

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

        public CommonResponse GetTourFromRegisterByUserIdAndDateRange(string userId, string startingDate, string endingDate)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "UserId", Value = userId},
                new CommonKeyValueObject() {Key = "EndingDate", Value = endingDate},
                new CommonKeyValueObject() {Key = "StartDate", Value = startingDate}
            };
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Conv_TourRegister_ByIdAndDateRange", objects);
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = dataTable;

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

        public CommonResponse GetTourFromRegisterForApprovalByUserIdAndMonth(string userId, string Month,string Year)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "UserId", Value = userId},
                new CommonKeyValueObject() {Key = "Month", Value = Month},
                new CommonKeyValueObject() {Key = "Year", Value = Year},
            };
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Conv_TourRegister_ForApproval_By_Id_Month", objects);
            try
            {
                List<TourRegisterItem> tourRegisterItems = new List<TourRegisterItem>();

                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            TourRegisterItem model = new TourRegisterItem()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Date = dataTable.Rows[i]["TDate"].ToString().Trim(),
                                From = dataTable.Rows[i]["FromAddress"].ToString().Trim(),
                                To = dataTable.Rows[i]["ToAddress"].ToString(),
                                By = dataTable.Rows[i]["JourneyBy"].ToString().Trim(),
                                Fare = dataTable.Rows[i]["Fare"].ToString().Trim(),
                                ApproveAmount = dataTable.Rows[i]["ApproveAmount"].ToString().Trim(),
                                Remarks = dataTable.Rows[i]["Remarks"].ToString().Trim()
                            };
                            tourRegisterItems.Add(model);
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = tourRegisterItems;

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

        public CommonResponse GetTourFromRegisterForApprovalById(string Id)
        {
            CommonResponse commonResponse = new CommonResponse();
            SqlProcedureManager procedureManager = SqlProcedureManager.Instance();
            List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
            {
                new CommonKeyValueObject() {Key = "Id", Value = Id}
            };
            DataTable dataTable = procedureManager.ExecuteSpGetDataTable("sp_Get_Conv_TourRegister_ForApproval_By_Id", objects);
            try
            {
                TourRegisterItem model = new TourRegisterItem();

                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            model = new TourRegisterItem()
                            {
                                Id = dataTable.Rows[i]["Id"].ToString().Trim(),
                                Date = dataTable.Rows[i]["TDate"].ToString().Trim(),
                                From = dataTable.Rows[i]["FromAddress"].ToString().Trim(),
                                To = dataTable.Rows[i]["ToAddress"].ToString(),
                                By = dataTable.Rows[i]["JourneyBy"].ToString().Trim(),
                                Fare = dataTable.Rows[i]["Fare"].ToString().Trim(),
                                ApproveAmount = dataTable.Rows[i]["ApproveAmount"].ToString().Trim(),
                                Remarks = dataTable.Rows[i]["Remarks"].ToString().Trim()
                            };
                        }

                        commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                        commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                        commonResponse.ResponseData = model;

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


        public CommonResponse ApproveSingleTourInRegister(string approver,TourRegisterItem tourRegister)
        {
            CommonResponse commonResponse = new CommonResponse();

            try
            {

                List<CommonKeyValueObject> objects = new List<CommonKeyValueObject>
                {
                    new CommonKeyValueObject() {Key = "Id", Value = tourRegister.Id},
                    new CommonKeyValueObject() {Key = "ApprovedAmount", Value = tourRegister.ApproveAmount},
                    new CommonKeyValueObject() {Key = "ApprovedBy", Value = approver},
                    new CommonKeyValueObject() {Key = "VerificationNote", Value = tourRegister.VerificationNote}
                };

                commonResponse = SqlProcedureManager.Instance().ExecuteNonSpQuery("sp_Up_Conv_TourRegisterApproveById", objects);

            }
            catch (Exception exception)
            {
                commonResponse.ResponseCode = Constants.ResponseCode.ResponseFailed;
                commonResponse.ResponseMsg = exception.Message;
                commonResponse.ResponseUserMsg = "Unable to upload Convince.";
            }

            return commonResponse;
        }
    }
}