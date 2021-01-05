using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEntities.Enums
{
  public  class GlobalEnums
    {
        public enum DBProvider
        {
            SqlClient = 1,
            Oracle = 2
        }
        public enum SqlType
        {
            Procedure = 1,
            SQL_Query = 2
        }
        public enum FieldType
        {
            Lebel = 1,
            TextBox = 2,
            Dropdown=3,
            CheckBox=4,
            RadioButton=5,
            DateTime=6,
            HiddenText=7,
            EmbededTextBox = 8,
            EmbededCheckBox = 9,
            EmbededDropdown = 10
        }
        public enum ExportType
        {
            PDF = 1,
            Execl = 2,
            CSV=3,
            DataGrid = 4
        }
        public enum AppId
        {
            FBReportWeb = 1,
            FBWeb = 2
        }
        
        public enum DBName
        {
            //FBSecurity = 1,
            //DigitalBanking = 2,
            FBReport = 1,//FB_Report ReadOnly
            FBReport_IO = 2,//FB_Report 
            FB_CBS = 3,//FloraBank_Online 
            DigitalBanking = 4, //FloraBank_Web
            FBForeignExchange = 5,//ForeignExchange
            FBSYSMAN = 6,//SYSMAN
            IB = 7
        }
       
        public enum MTI
        {
            GetToken = 1,
            Login = 2,
            Logout = 3,
            ForgotPassword = 4,
            ChangePassword = 5,
            GetPersonalInfo = 6, 
            UserFeedback = 7,
            GetProfilePic = 8,

            CheckCustomer = 10,
            CustomerDetails = 11,
            CustomerRegistration = 12,
            UpdatePersonalInfo = 13,
            UpdateCustomerAddress = 14,
            ManageDocument = 15,
            
            VerifyMobileNo = 21,
            SendOtp = 22,
            ReSendOTP = 23,
            VerifyOTP = 24,

            GetDivisionList = 31,
            GetDistrictList = 32,
            GetBankList = 33,

            TagAccount =41,
            AccountVerification = 42,
            DobVerification = 43,
            GetTaggedAccList = 44,
            GetOperatorList = 45,
            GetWalletBalance = 46,
            GetCustomerStatement = 47,

            ValidAddMoney = 51,
            AddMoneyToWallet = 52,
            WalletToBankTrn = 53,
            WalletToWallet = 54,
            BankToBank = 55,

            MobileTopup =61

        }

        public enum ResponseCode
        {
            Success = 100,
            InvalidApiKey = 101,
            OperationFailed = 102,
            InvalidMobile = 103,
            InvalidEmail = 104,
            InvalidUserId = 105,
            InvalidInputParameter = 106,
            NoDataFound = 107,
            AlreadyExist = 108,
            InvalidAccount = 109,
            SameAccount = 110,
            SystemError = 111,
            NoAction = 112,
            DuplicateOperation = 113
        }

        public enum LogType
        {
            ReportQueryLog = 1,
            SQL_Query = 2
        }
    }
}
