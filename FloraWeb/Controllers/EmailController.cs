using FloraWeb.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace FloraWeb.Controllers
{
    public class EmailController : ApiController
    {
        [HttpPost]

        public CommonResponse SendMail(string usermail, string Subject, string messageboddy)
        {


            //EmailController emailController = new EmailController();
            //var common = emailController.SendMail("to@gmail.com", "Test Email Title", "Test Body");

            string hostIp = string.Empty;
            try
            {

                Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                MailMessage message = new MailMessage();
                message.From = new MailAddress(settings.Smtp.From);
                message.To.Add(usermail.Trim());
                message.Subject = Subject;
                message.Body = messageboddy;
                message.IsBodyHtml = false;
                SmtpClient client = new SmtpClient();//smtp.gmail.com 587
                client.Host = hostIp = settings.Smtp.Network.Host;
                client.Port = settings.Smtp.Network.Port;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
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
                        ResponseMsg = "Failed to send mail : Response from Host(" + hostIp + "):" + ex.InnerException.ToString()
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