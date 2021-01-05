using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Linq;

namespace GlobalEntities.Entities
{

    [FlagsAttribute]
    public enum DatabaseErrorMessageDisplayLevel
    {
        None = 0,
        Message = 1,
        Notice = 2,
        Warnning = 4,
        Error = 8,
        All = 255

    }
    /// <summary>
    /// Summary description for GlobalEntity
    /// </summary>
    [Serializable]
    public class GlobalEntity
    {

        public string WebSiteUrl { get; set; }
        //public string UserLevel { get; set; }
        public bool UserLogIn { get; set; }
        public bool IsAdminUser { get; set; }
        public bool IsGlobalUser { get; set; }
        public bool IsSpecialUser { get; set; }
        public string HeadOfficeBranch { get; set; }
        //public string BranchCode { get; set; }
        public string UserID { get; set; }
        public string BranchCode { get; set; }
        public string PubBankName { get; set; }
        public string PubBankAddr { get; set; }
        public string PubFbankPhone { get; set; }
        public string PubBankFax { get; set; }
        public string PubZoneName { get; set; }
        public string PubZoneCode { get; set; }
        public string PubBankBranch { get; set; }
        public string PubBBbankCode { get; set; }
        public string PubBankPalace { get; set; }
        public string IslamicBankYN { get; set; }
        public string IndependantBrYN { get; set; }
        public string CountryCode { get; set; }
        public string LienceNo { get; set; }
        public string Userpass { get; set; }
        public string Username { get; set; }
        public int UserLevel { get; set; }
        public DateTime TDate { get; set; }
        public string EnabledYN { get; set; }
        public DateTime ModifyingDate { get; set; }
        public string SamePswdYN { get; set; }
        public string MachineID { get; set; }
        public string PCrestrictYN { get; set; }
        public string CentralLockYN { get; set; }

        #region System Data Format

        private static string syslcamt_viewformat;
        public string Syslcamt_viewformat
        {
            get
            {
                if (string.IsNullOrEmpty(syslcamt_viewformat))
                {
                    syslcamt_viewformat = "99,99,99,99,999.99";
                }
                return syslcamt_viewformat;
            }
            set
            {
                syslcamt_viewformat = value;
            }
        }

        private static string sysfcamt_viewformat;
        public string Sysfcamt_viewformat
        {
            get
            {
                if (string.IsNullOrEmpty(sysfcamt_viewformat))
                {
                    sysfcamt_viewformat = "99,99,99,999.9999";
                }
                return sysfcamt_viewformat;
            }
            set
            {
                sysfcamt_viewformat = value;
            }
        }

        private static string syscrate_viewformat;
        public string Syscrate_viewformat
        {
            get
            {
                if (string.IsNullOrEmpty(syscrate_viewformat))
                {
                    syscrate_viewformat = "9999.9999";
                }
                return syscrate_viewformat;
            }
            set
            {
                syscrate_viewformat = value;
            }
        }

        private static string sysdate_entryformat;
        public string Sysdate_entryformat
        {
            get
            {
                //if (string.IsNullOrEmpty(sysdate_entryformat))
                //{
                //    sysdate_entryformat = "9999.9999";
                //}
                return sysdate_entryformat;
            }
            set
            {
                sysdate_entryformat = value;
            }
        }

        #endregion

        #region System Data Format Mathod
        public string FormatLocalCurrencyAmount(double Amount)
        {
            string _formatedAmount = string.Empty;
            _formatedAmount = Amount.ToString(Syslcamt_viewformat.Replace('9', '#'));
            return _formatedAmount;
        }
        public string FormatForeignCurrencyAmount(double Amount)
        {
            string _formatedAmount = string.Empty;
            _formatedAmount = Amount.ToString(Sysfcamt_viewformat.Replace('9', '#'));
            return _formatedAmount;
        }
        public string FormatCurrencyRate(double Amount)
        {
            string _formatedAmount = string.Empty;
            _formatedAmount = Amount.ToString(Syscrate_viewformat.Replace('9', '#'));
            return _formatedAmount;
        }
        #endregion
        public int BankCompanyID { get; set; }
        public string BANKCOMAPNYNAME { get; set; }
        public string Accformatcode { get; set; }

        public string ReportYear { get; set; }
        public string InterestProfit
        {
            get
            {
                //if (ConfigurationManager.AppSettings.AllKeys.Contains("InterestProfit"))
                //{
                //    return ConfigurationManager.AppSettings["InterestProfit"];
                //}
                //else
                //{
                if (IslamicBankYN == "Y")
                {
                    return "Profit";
                }
                else
                {
                    return "Interest";
                }
                //}
            }
        }

        public string LoanInvestment
        {
            get
            {
                //if (ConfigurationManager.AppSettings.AllKeys.Contains("LoanInvestment"))
                //{
                //    return ConfigurationManager.AppSettings["LoanInvestment"];
                //}
                //else
                //{
                if (IslamicBankYN == "Y")
                {
                    return "Investment";
                }
                else
                {
                    return "Loan";
                }
                //}
            }
        }

        public bool IsRoleBased { get; set; }




        public int FloraBankID { get; set; }

        public DateTime ServerDate { get; set; }
        public string SQLServerDate
        {
            get
            {
                return ServerDate.ToString("dd/MMM/yyyy");
            }
        }

        public string CurrencyCode { get; set; }
        public string DayEndPrcsDate { get; set; }
        public string PictureLocation { get; set; }
        public string Country { get; set; }
        public string OneStopServiceYN { get; set; }

        public string PreparedBy { get; set; }
        public string AuthorizedSig { get; set; }
        public string BankLogo { get; set; }
        public int FinancialYearStart { get; set; }
        public int ReportdwhYN { get; set; }
        public int PasswordHistoryTime { get; set; }
        public DateTime OpStartDate { get; set; }
        public DateTime OpEndDate { get; set; }
        public string OnLineYN { get; set; }
        public DateTime LocaltrnDt { get; set; }
        public DateTime LastReplDate { get; set; }
    }


}
