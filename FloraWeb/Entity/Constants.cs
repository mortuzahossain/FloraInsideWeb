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
        }


        public class MTI
        {
            public const string Login = "1";
            public const string AddTourRegister = "2";
            public const string Get_Course = "101";
        }
    }
}