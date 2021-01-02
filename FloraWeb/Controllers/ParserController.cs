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

                #region Users
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
                case Constants.MTI.GetUserProfile:
                    UserProfile getUserProfile = JsonConvert.DeserializeObject<UserProfile>(commonRequest.Data);
                    return new UsersRepository().GetUserProfile(getUserProfile);
                case Constants.MTI.UpdateUsersPassword:
                    UpdateUserPassword updateUserPassword = JsonConvert.DeserializeObject<UpdateUserPassword>(commonRequest.Data);
                    return new UsersRepository().UpdateUsersPassword(updateUserPassword.UserId, updateUserPassword.Password);
                case Constants.MTI.ForgetUserPassword:
                    ForgetPassword forgetPassword = JsonConvert.DeserializeObject<ForgetPassword>(commonRequest.Data);
                    return new UsersRepository().ForgetPassword(forgetPassword.Email);
                case Constants.MTI.GetAllUserProfileForContactBook:
                    return new UsersRepository().GetAllUserProfileForContactBook();
                case Constants.MTI.UploadConvince:
                    Convince convince = JsonConvert.DeserializeObject<Convince>(commonRequest.Data);
                    TourRegister register = new TourRegister()
                    {
                        ClientId = convince.clientBank,
                        Fare = convince.fare,
                        FromAddress = convince.fromAddress,
                        ToAddress = convince.toAddress,
                        UserId = convince.userId,
                        IssueId = convince.issueId,
                        JourneyBy = convince.journeyBy,
                        Remarks = convince.remarks,
                        Lan = convince.lan,
                        Lat = convince.lat,
                        UpOrDown = convince.upOrDown.ToString(),
                        TDate = convince.createDtime,
                        TerminalId = commonRequest.TerminalId

                    };
                    return new ConvinceBillRepository().AddTourInRegister(register);
                case Constants.MTI.GetConvincesByUserId:
                    UserParam userParam = JsonConvert.DeserializeObject<UserParam>(commonRequest.Data);
                    return new ConvinceBillRepository().GetTourFromRegisterByUserId(userParam.UserId);
                #endregion

                #region FAQ
                case Constants.MTI.GetAllFaq:
                    return new FaqRepository().GetAllFaq();
                case Constants.MTI.GetFaqById:
                    return new FaqRepository().GetFaqById(commonRequest.Data);
                case Constants.MTI.UpdateFaqVote:
                    UpdateFaq updateFaq = JsonConvert.DeserializeObject<UpdateFaq>(commonRequest.Data);
                    return new FaqRepository().UpdateFaqVote(updateFaq.Id, updateFaq.Vote);
                #endregion

                default:
                    return commonResponse;
            }


        }


        #region API Entity
        // Required Model Class for API

        class UpdateUserPassword
        {
            public string UserId { get; set; }
            public string Password { get; set; }
        }
        class UpdateFaq
        {
            public string  Id { get; set; }
            public string Vote { get; set; }
        }
        class ForgetPassword
        {
            public string Email { get; set; }
        }
        class Convince
        {
            public int id { get; set; }
            public string userId { get; set; }
            public int upOrDown { get; set; }
            public string issueId { get; set; }
            public string clientBank { get; set; }
            public string fromAddress { get; set; }
            public string toAddress { get; set; }
            public string journeyBy { get; set; }
            public string fare { get; set; }
            public string remarks { get; set; }
            public string uploadStatus { get; set; }
            public string createDtime { get; set; }
            public string lat { get; set; }
            public string lan { get; set; }
        }
        class UserParam
        {
            public string UserId { get; set; }
        }
        #endregion
    }
}
