using System.Configuration;
using Mock4Net.Core;

namespace UnitTests
{
    public abstract class IntegrationTestMockServer
    {
        private FluentMockServer _mockServer;

        protected void Setup()
        {
            _mockServer = FluentMockServer.Start();

            ConfigurationManager.AppSettings["serviceUrl"] = "http://localhost:" + _mockServer.Port;
        }

        protected void TearDown()
        {
            _mockServer.Reset();
        }

        protected void GivenEmailSendIsSuccessful()
        {
            _mockServer
                .Given(
                    Requests
                        .WithUrl("/messages/emails")
                        .UsingPost())
                .RespondWith(
                    Responses
                        .WithStatusCode(200));
        }

        protected void GivenEmailSendIsUnsuccessful()
        {
            _mockServer
                .Given(
                    Requests
                        .WithUrl("/messages/emails")
                        .UsingPost())
                .RespondWith(
                    Responses
                        .WithStatusCode(400)
                        .WithHeader("Content-Type", "application/json")
                        .WithBody("That message is too long!"));
        }

        protected void GivenEmailServiceIsBroken()
        {
            _mockServer
                .Given(
                    Requests
                        .WithUrl("/messages/emails")
                        .UsingPost())
                .RespondWith(
                    Responses
                        .WithStatusCode(500)
                        .WithHeader("Content-Type", "application/json")
                        .WithBody("Something went wrong!"));
        }

        protected void GivenMemoSendIsSuccessful()
        {
            _mockServer
                .Given(
                    Requests
                        .WithUrl("/messages/memos")
                        .UsingPost())
                .RespondWith(
                    Responses
                        .WithStatusCode(200));
        }

        protected void GivenMemoSendIsUnsuccessful()
        {
            _mockServer
                .Given(
                    Requests
                        .WithUrl("/messages/memos")
                        .UsingPost())
                .RespondWith(
                    Responses
                        .WithStatusCode(400)
                        .WithHeader("Content-Type", "application/json")
                        .WithBody("That message is too long!"));
        }

        protected void GivenMemoServiceIsBroken()
        {
            _mockServer
                .Given(
                    Requests
                        .WithUrl("/messages/memos")
                        .UsingPost())
                .RespondWith(
                    Responses
                        .WithStatusCode(500)
                        .WithHeader("Content-Type", "application/json")
                        .WithBody("Something went wrong!"));
        }
    }
}
