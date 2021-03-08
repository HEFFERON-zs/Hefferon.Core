using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Hefferon.Core.Mail
{
    /// <summary>
    /// Defines simple mail transfer protocol client functionality.
    /// </summary>
    public interface ISmtpClient
    {
        /// <summary>
        /// Sends email defined with <paramref name="from"/>, <paramref name="to"/>, <paramref name="subject"/>, <paramref name="body"/> and <paramref name="attachments"/>.
        /// </summary>
        /// <param name="from">From email address.</param>
        /// <param name="to">From email addresses.</param>
        /// <param name="subject">Email subject.</param>
        /// <param name="body">Email content.</param>
        /// <param name="attachments">Collection of email attachments.</param>
        public void Send(string from, List<string> to, string subject, string body, List<Attachment> attachments = null, List<string> BCC = null);
    }
}
