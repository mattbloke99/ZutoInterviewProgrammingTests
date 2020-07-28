using System.Threading.Tasks;
using ZutoKata.Models;

namespace ZutoKata.Services
{
    public interface ISender
    {
        Task<ISentResponse> Send(ISendable itemToSend);
    }
}
