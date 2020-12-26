using System.Web.Http;
using FloraWeb.Entity;

namespace FloraWeb.Controllers
{
    public class ParserController : ApiController
    {
        [HttpPost]
        public CommonResponse Post(CommonRequest commonRequest)
        {

            CommonResponse commonResponse = new CommonResponse
            {
                ResponseCode = Constants.ResponseCode.ResponseFailed,
                ResponseMsg = Constants.ResponseMsg.ResponseFailed,
                ResponseUserMsg = Constants.ResponseMsg.ResponseUserMsgFailed
            };


            if (string.IsNullOrEmpty(commonRequest.Mti) || string.IsNullOrEmpty(commonRequest.Data)) return commonResponse;

            switch (commonRequest.Mti)
            {
                case "0":
                    commonResponse.ResponseCode = Constants.ResponseCode.ResponseSuccess;
                    commonResponse.ResponseMsg = Constants.ResponseMsg.ResponseSuccess;
                    commonResponse.ResponseUserMsg = Constants.ResponseMsg.ResponseSuccess;
                    return commonResponse;
                case Constants.MTI.Login:
                        return commonResponse;

                case Constants.MTI.Get_Courses:
                    return commonResponse;
                case Constants.MTI.Get_Course:
                    return commonResponse;

                default:
                    return commonResponse;
            }


        }
    }
}
