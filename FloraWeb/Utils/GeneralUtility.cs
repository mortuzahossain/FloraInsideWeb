using System;
using System.Web;
using FloraWeb.Entity;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web.Configuration;

namespace FloraWeb.Utils
{
    public class GeneralUtility
    {
        public static CommonResponse SendMail(string toAddress, string subject, string messageBody)
        {


            //EmailController emailController = new EmailController();
            //var common = emailController.SendMail("to@gmail.com", "Test Email Title", "Test Body");

            string hostIp = string.Empty;
            try
            {

                Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                MailMessage message = new MailMessage();
                if (settings != null)
                {
                    message.From = new MailAddress(settings.Smtp.From);
                    message.To.Add(toAddress.Trim());
                    message.Subject = subject;
                    message.Body = messageBody;
                    message.IsBodyHtml = false;
                    SmtpClient client = new SmtpClient(); //smtp.gmail.com 587
                    client.Host = hostIp = settings.Smtp.Network.Host;
                    client.Port = settings.Smtp.Network.Port;
                    client.UseDefaultCredentials = false;
                    client.Credentials =
                        new NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
                    client.EnableSsl = settings.Smtp.Network.EnableSsl;
                    //client.EnableSsl = false;
                    try
                    {
                        client.Send(message);

                        return new CommonResponse
                        {
                            ResponseCode = Constants.ResponseCode.ResponseSuccess,
                            ResponseMsg = Constants.ResponseMsg.ResponseSuccess
                        };
                    }
                    catch (Exception ex)
                    {
                        return new CommonResponse
                        {
                            ResponseCode = Constants.ResponseCode.ResponseFailed,
                            ResponseMsg = "Failed to send mail : Response from Host(" + hostIp + "):" +
                                          ex.InnerException
                        };
                    }
                }
                else
                {
                    return new CommonResponse
                    {
                        ResponseCode = Constants.ResponseCode.ResponseFailed,
                        ResponseMsg = "Mail setting not configured yet."
                    };
                }
            }
            catch (Exception exx)
            {
                return new CommonResponse
                {
                    ResponseCode = Constants.ResponseCode.ResponseFailed,
                    ResponseMsg = "Failed to send mail. Error:" + exx.Message
                };
            }
        }


    }
}