using System.Net;

namespace ZutoKata.Models
{
    public interface ISentResponse
    {
        bool Success { get; }

        HttpStatusCode StatusCode { get;  }
    }
}
