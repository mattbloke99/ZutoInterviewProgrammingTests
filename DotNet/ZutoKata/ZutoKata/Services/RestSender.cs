using System;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using ZutoKata.Models;

namespace ZutoKata.Services
{
    public class RestSender : ISender
    {
        private readonly IRestClient _client;

        public RestSender()
        {
            var serviceUrl = ConfigurationManager.AppSettings["serviceUrl"];
            _client = new RestClient(serviceUrl);
        }

        public async Task<ISentResponse> Send(ISendable itemToSend)
        {
            //TODO change this so that we can handle several SendableTypes perhaps with the strategy pattern
            //TODO remove hardcoding of endpoints to AppSettings
            var url = itemToSend.Type == SendableTypes.Memo ? "/messages/memos" : "/messages/emails";

            //TODO remove hardcoding of http method make this more flexibles so that method is passed
            var request = new RestRequest(url, Method.POST);

            //TODO unecessary anonymous class, this should be refactored to send an ISendable object
            request.AddJsonBody(new
            {
                recipient = itemToSend.Recipient,
                subject = itemToSend.Subject,
                message = itemToSend.Message
            });

            var response = await _client.ExecuteTaskAsync(request);
      
            return new SentResponse(response.StatusCode);
        }
    }
}
