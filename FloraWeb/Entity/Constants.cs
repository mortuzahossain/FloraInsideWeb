namespace FloraWeb.Entity
{
    public class Constants
    {
        public static string CookieName = "wallpaperadmin";
        public static string CookieUserId = "USER_ID";

        public class ResponseCode
        {
            public static int ResponseSuccess = 100;
            public static int ResponseFailed = 101;
        }

        public class ResponseMsg
        {
            public static string ResponseSuccess = "Successful";
            public static string ResponseFailed = "Failed";
            public static string ResponseUserMsgFailed = "Something went wrong. Please try again.";
            public static string ResponseLoginSuccess = "Login Successful";
            public static string ResponseLoginFailed = "Login Failed! Please try with correct UserId and Password.";
        }


        public class MTI
        {
            public const string Login = "1";
            public const string AddTourRegister = "2";
            public const string UpdateUsersProfile = "3";
            public const string UpdateUsersProfileImage = "4";
            public const string GetAllFaq = "5";
            public const string GetFaqById = "6";
            public const string UpdateFaqVote = "7";
            public const string GetUserProfile = "8";
            public const string UpdateUsersPassword = "9";
            public const string GetAllUserProfileForContactBook = "10";
            public const string ForgetUserPassword = "11";
        }
    }
}