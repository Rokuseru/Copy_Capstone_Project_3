using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace CapstoneProject_3
{
    public class Mail
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string From { get; set; }
        public bool RequireAuthentication { get; set; }
        public bool DeleteFilesAfterSend { get; set; }

        public List<string> To { get; set; }
        public List<string> Cc { get; set; }
        public List<string> Bcc { get; set; }
        public List<string> AttachmentFiles { get; set; }

        #region appi declarations

        internal enum MoveFileFlags
        {
            MOVEFILE_REPLACE_EXISTING = 1,
            MOVEFILE_COPY_ALLOWED = 2,
            MOVEFILE_DELAY_UNTIL_REBOOT = 4,
            MOVEFILE_WRITE_THROUGH = 8
        }
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool MoveFile(string lpExistingFilename, string lpNewFileName,
                                    MoveFileFlags dwFlags);
        #endregion
        public Mail()
        {
            To = new List<string>();
            Cc = new List<string>();
            Bcc = new List<string>();
            AttachmentFiles = new List<string>();
            From = "roxsyle7@gmail.com";
        }

        public void Send()
        {
            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = false,
            };

            if (RequireAuthentication)
            {
                var credentials = new NetworkCredential("rosyle7@gmail.com",
                                                        "rcmb0803");
                client.Credentials = credentials;
            }

            var message = new MailMessage
            {
                Sender = new MailAddress(From, From),
                From = new MailAddress(From, From)
            };

            AddDestinataryToList(To, message.To);
            AddDestinataryToList(Cc, message.CC);
            AddDestinataryToList(Bcc, message.Bcc);

            message.Subject = Title;
            message.Body = Text;
            message.IsBodyHtml = false;
            message.Priority = MailPriority.High;

            var attachments = AttachmentFiles.Select(file => new Attachment(file));
            foreach (var attachment in attachments)
                message.Attachments.Add(attachment);

            client.Send(message);
            if (DeleteFilesAfterSend)
                AttachmentFiles.ForEach(deleteFile);
        }
        private void AddDestinataryToList(IEnumerable<string> from,
                                        ICollection<MailAddress> mailAddressesCollection)
        {
            foreach (var destinatary in from)
                mailAddressesCollection.Add(new MailAddress(destinatary, destinatary));
        }
        private void deleteFile(string filePath)
        {
            MoveFile(filePath, null, MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT);
        }

    }
}
