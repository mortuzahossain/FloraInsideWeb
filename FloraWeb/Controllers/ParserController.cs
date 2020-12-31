using System.Web.Http;
using FloraWeb.Entity;
using FloraWeb.Models;
using FloraWeb.Repository;
using Newtonsoft.Json;

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
                    LoginViewModel loginViewModel = JsonConvert.DeserializeObject<LoginViewModel>(commonRequest.Data);
                    return new UsersRepository().UsersLogin(loginViewModel);

                case Constants.MTI.AddTourRegister:
                    TourRegister tourRegister = JsonConvert.DeserializeObject<TourRegister>(commonRequest.Data);
                    return new ConvinceBillRepository().AddTourInRegister(tourRegister);
                case Constants.MTI.UpdateUsersProfile:
                    UserProfile userProfile = JsonConvert.DeserializeObject<UserProfile>(commonRequest.Data);
                    return new UsersRepository().UpdateUsersProfile(userProfile);
                case Constants.MTI.UpdateUsersProfileImage:
                    UserProfile userProfileImage = JsonConvert.DeserializeObject<UserProfile>(commonRequest.Data);
                    return new UsersRepository().UpdateUsersProfileImage(userProfileImage);

                default:
                    return commonResponse;
            }


        }
    }
}
