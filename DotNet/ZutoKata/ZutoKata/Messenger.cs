using System;
using System.Threading.Tasks;
using ZutoKata.Models;
using ZutoKata.Services;

namespace ZutoKata
{
    public class Messenger
    {
        private readonly ISender _sender;

        public Messenger(ISender sender)
        {
            _sender = sender;
        }

        public async Task<ISentResponse> SendEmail(string to, string subject, string message)
        {
            var email = new Email(to, subject, message);
            return await _sender.Send(email);
        }

        public async Task<ISentResponse> SendMemo(string to, string subject, string message)
        {
            var memo = new Memo(to, subject, message);
            return await _sender.Send(memo);
        }
    }
}
