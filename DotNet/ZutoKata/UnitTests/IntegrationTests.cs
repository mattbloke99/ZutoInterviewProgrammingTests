using System.Configuration;
using System.Net;
using System.Runtime;
using System.Threading.Tasks;
using NUnit.Framework;
using ZutoKata;
using ZutoKata.Services;
using ZutoKata.Models;

namespace UnitTests
{
    [TestFixture]
    public class IntegrationTests : IntegrationTestMockServer
    {
        private Messenger _messenger;

        [SetUp]
        public new void Setup()
        {
            base.Setup();
            var sender = new RestSender();
            _messenger = new Messenger(sender);
        }
        
        [TearDown]
        public new void TearDown()
        {
            base.TearDown();
        }

        [Test]
        public async Task Email_SuccessfulSend()
        {
            GivenEmailSendIsSuccessful();

            var response = await _messenger.SendEmail("me@zuto.com", "Test Message", "This is a Test!");

            Assert.That(response.Success, Is.True);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Email_UnsuccessfulSend_OurFault()
        {
            GivenEmailSendIsUnsuccessful();

            var response = await _messenger.SendEmail("me@zuto.com", "Test Message", "This is a Test!");

            Assert.That(response.Success, Is.False);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task Email_UnsuccessfulSend_ServerDown()
        {
            GivenEmailServiceIsBroken();

            var response = await _messenger.SendEmail("me@zuto.com", "Test Message", "This is a Test!");

            Assert.That(response.Success, Is.False);
            Assert.That(response.StatusCode, Is.EqualTo( HttpStatusCode.InternalServerError));
        }



        [Test]
        public async Task Memo_SuccessfulSend()
        {
            GivenMemoSendIsSuccessful();

            var response = await _messenger.SendMemo("me@zuto.com", "Test Message", "This is a Test!");

            Assert.That(response.Success, Is.True);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Memo_UnsuccessfulSend_OurFault()
        {
            GivenMemoSendIsUnsuccessful();

            var response = await _messenger.SendMemo("me@zuto.com", "Test Message", "This is a Test!");

            Assert.That(response.Success, Is.False);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task Memo_UnsuccessfulSend_ServerDown()
        {
            GivenMemoServiceIsBroken();

            var response = await _messenger.SendMemo("me@zuto.com", "Test Message", "This is a Test!");

            Assert.That(response.Success, Is.False);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }

    }
}
