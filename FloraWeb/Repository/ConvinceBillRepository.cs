using FloraWeb.Database;
using FloraWeb.Entity;
using System;
using System.Collections.Generic;

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
            }

            return commonResponse;
        }
    }
}