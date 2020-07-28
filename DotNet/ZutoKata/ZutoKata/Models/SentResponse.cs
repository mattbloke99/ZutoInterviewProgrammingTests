using System.Net;

namespace ZutoKata.Models
{
    public class SentResponse : ISentResponse
    {
        public SentResponse( HttpStatusCode statusCode)
        {
            StatusCode = statusCode;

            //TODO quick and dirty way, any other than OK will be false
            //TODO this logic can be moved to the getter for the success property
            Success = statusCode == HttpStatusCode.OK;
      
        }

        public bool Success { get; }

        public HttpStatusCode StatusCode { get;  }

    }
}
