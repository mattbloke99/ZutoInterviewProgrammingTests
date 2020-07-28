namespace ZutoKata.Models
{
    public interface ISendable
    {
        SendableTypes Type { get; }

        string Recipient { get; }
        string Subject { get; }
        string Message { get; }
    }
}
