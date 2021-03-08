using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Hefferon.Core.Mail
{
    /// <summary>
    /// Implements <see cref="ISmtpClient"/> interface and provides simple mail transfer protocol client functionality.
    /// </summary>
    public class SmtpClient : ISmtpClient
    {
        #region Fields

        int _port;
        string _host;
        string _user; 
        string _password;
        bool _enableSsl;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Initializes new instance of <see cref="SmtpClient"/> class.
        /// </summary>
        /// <param name="configurationProvider">Concrete <see cref="IConfigurationProvider"/> interface implementation.</param>
        public SmtpClient(int port, string host, string user, string password, bool enableSsl)
        {
            _port = port;
            _host = host;
            _user = user;
            _password = password;
            _enableSsl = enableSsl;
        }

        #endregion //Constructors

        #region Interface Implementations

        #region ISmtpClient Members

        /// <summary>
        /// Sends email defined with <paramref name="from"/>, <paramref name="to"/>, <paramref name="subject"/>, <paramref name="body"/> and <paramref name="attachments"/>.
        /// </summary>
        /// <param name="from">From email address.</param>
        /// <param name="to">From email addresses.</param>
        /// <param name="subject">Email subject.</param>
        /// <param name="body">Email content.</param>
        /// <param name="attachments">Collection of email attachments.</param>
        /// <param name="BCC"></param>
        public void Send(string from, List<string> to, string subject, string body, List<Attachment> attachments = null, List<string> BCC = null)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient
            {
                Port = _port,
                Host = _host,
                Timeout = 30,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                _user,
                _password)
            };

            client.EnableSsl = _enableSsl;


            MailMessage mailMessage = new MailMessage();

            foreach (string mailAddress in to)
            {
                mailMessage.To.Add(new MailAddress(mailAddress));
            }

            if (BCC != null)
            {
                foreach (string mailAddress in BCC)
                {
                    mailMessage.Bcc.Add(new MailAddress(mailAddress));
                }
            }

            mailMessage.From = new MailAddress(from);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            if (attachments != null && attachments.Count > 0)
            {
                foreach (Attachment attachment in attachments)
                {
                    mailMessage.Attachments.Add(attachment);
                }
            }

            client.Send(mailMessage);
        }

        #endregion // ISmtpClient Members

        #endregion // Interface Implementations
    }
}
