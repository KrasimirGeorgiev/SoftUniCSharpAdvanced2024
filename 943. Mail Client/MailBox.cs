using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }
        public int Capacity { get; set; }

        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Capacity > Inbox.Count)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
            => Inbox.Remove(Inbox.Where(x => x.Sender == sender).FirstOrDefault());

        public int ArchiveInboxMessages()
        {
            var count = Inbox.Count();
            Archive.AddRange(Inbox);
            Inbox.Clear();

            return count;
        }

        public string GetLongestMessage()
            => Inbox.OrderByDescending(x => x.Body.Length).First().ToString();

        public string InboxView()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Inbox:");
            foreach (Mail mail in Inbox)
            {
                sb.AppendLine(mail.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
