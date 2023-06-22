using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Lab_AWS
{
    public static class Sms
    {
        public static void SendSmsAdmin(string text)
        {
            var accountSid = "AC714559f7a99438604d99a4d06bc625d6";
            var authToken = "1851f225ea3884f6275f617043491aae";
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: text,
                from: new Twilio.Types.PhoneNumber("+12543799780"),
                to: new Twilio.Types.PhoneNumber("+840987623044")
            );
            Console.WriteLine(message.Sid);
        }
    /*    public static void SendEmail(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("kietvan.31201024409@st.ueh.edu.vn", "0906889483");
            var mailMessage = new MailMessage("kietvan.31201024409@st.ueh.edu.vn", to, subject, body);
            smtpClient.Send(mailMessage);
            int kiet = 0;
        }*/
    }
   

}
