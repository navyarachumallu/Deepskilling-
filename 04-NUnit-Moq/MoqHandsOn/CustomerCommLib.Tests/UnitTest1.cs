using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerCommLib.Tests
{
    public class Tests
    {
        [Test]
        public void SendMailToCustomer_Should_Call_SendMail_Once()
        {
            // Arrange
            var mockMailSender = new Mock<IMailSender>();
            var customerComm = new CustomerComm(mockMailSender.Object);

            // Act
            bool result = customerComm.SendMailToCustomer();

            // Assert
            Assert.That(result, Is.True);

            mockMailSender.Verify(x =>
                x.SendMail(
                    "cust123@abc.com",
                    "Some Message"),
                Times.Once);
        }
    }
}
