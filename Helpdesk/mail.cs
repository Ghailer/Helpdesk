using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MailKit;
using MimeKit;


namespace Helpdesk
{
    class mail
    {
        string username;
        string password;

        public mail(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void SendMail(string username, string password, string body, string subject)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(username+ "@arcom.net.pl"));
            message.To.Add(new MailboxAddress("rafal.szmajser@arcom.net.pl"));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("mail.arcom.net.pl", 465, true);
                    //server, port, ssl

                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(username, password);

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }

        }
     
    }
}
