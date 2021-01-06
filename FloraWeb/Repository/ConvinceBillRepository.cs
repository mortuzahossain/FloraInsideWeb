using FloraWeb.Database;
using FloraWeb.Entity;
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
    }
}