using Limilabs.Client.IMAP;
using Limilabs.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Imap imap = new Imap())
            {
                imap.Connect("imap.gmail.com", 993, true);
                imap.Login("user", "password");                
                imap.SelectInbox();
                List<long> uids = imap.Search(Flag.All);
                foreach (long uid in uids)
                {
                    IMail email = new MailBuilder()
                        .CreateFromEml(imap.GetMessageByUID(uid));
                    Console.WriteLine(email.Subject);
                }
                imap.Close();
            }

        }
    }
}
