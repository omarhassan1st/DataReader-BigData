using System.Net;
using System.Net.Mail;

namespace DataReader
{
    class Licenses
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public static void SendNewMsg(string MSG)
        {
            if (CheckForInternetConnection())
            {
                try
                {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    string EmailBody = MSG;
                    SmtpClient Client = new SmtpClient("smtp.gmail.com", 587);
                    MailMessage mailMessage = new MailMessage();
                    string Email = Querys.Reader_SingleValue("select E_Mail from OWNER");
                    mailMessage.From = new MailAddress(Email);
                    mailMessage.To.Add(Email);
                    mailMessage.Subject = "Message From NovaTool (Reader) ";
                    Client.UseDefaultCredentials = false;
                    Client.EnableSsl = true;
                    Client.Credentials = new NetworkCredential("NovaToolsReader@gmail.com", "New123456");
                    mailMessage.Body = EmailBody;

                    Client.Send(mailMessage);
                }
                catch
                {

                }
            }
        }
    }
}
