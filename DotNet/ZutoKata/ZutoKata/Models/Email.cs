namespace ZutoKata.Models
{
    public class Email : ISendable
    {
        public SendableTypes Type => SendableTypes.Email;

        public string Recipient { get; }
        public string Subject { get; }
        public string Message { get; }

        public Email(string recipient, string subject, string message)
        {
            Recipient = recipient;
            Subject = subject;
            Message = message;
        }
    }
}
