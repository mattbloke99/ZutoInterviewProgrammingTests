using ZutoKata.Services;

namespace ZutoKata.Models
{
    public class Memo : ISendable
    {
        public SendableTypes Type => SendableTypes.Memo;
        //TODO, DRY this should inherit from an abstract class

        public string Recipient { get; }
        public string Subject { get; }
        public string Message { get; }

        public Memo(string recipient, string subject, string message)
        {
            Recipient = recipient;
            Subject = subject;
            Message = message;
        }
    }
}