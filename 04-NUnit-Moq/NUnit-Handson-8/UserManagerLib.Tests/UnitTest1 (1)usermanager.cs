using NUnit.Framework;
using UserManagerLib;
using System;

namespace UserManagerLib.Tests
{
    public class Tests
    {
        private User user;

        [SetUp]
        public void Setup()
        {
            user = new User();
        }

        [Test]
        public void ValidatePANCardNumber_ValidPAN_ReturnsValid()
        {
            string result = user.ValidatePANCardNumber("ABCDE1234F");

            Assert.That(result, Is.EqualTo("Valid"));
        }

        [Test]
        public void ValidatePANCardNumber_NullPAN_ThrowsNullReferenceException()
        {
            var ex = Assert.Throws<NullReferenceException>(() =>
                user.ValidatePANCardNumber(null));

            Assert.That(ex.Message, Is.EqualTo("Invalid Pan Card Number"));
        }

        [Test]
        public void ValidatePANCardNumber_EmptyPAN_ThrowsNullReferenceException()
        {
            var ex = Assert.Throws<NullReferenceException>(() =>
                user.ValidatePANCardNumber(""));

            Assert.That(ex.Message, Is.EqualTo("Invalid Pan Card Number"));
        }

        [Test]
        public void ValidatePANCardNumber_InvalidLength_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() =>
                user.ValidatePANCardNumber("ABC123"));

            Assert.That(ex.Message,
                Is.EqualTo("Pan Card Number Should contain only 10 characters"));
        }

        [Test]
        public void CreateUser_ValidUser_DoesNotThrowException()
        {
            User newUser = new User
            {
                FirstName = "John",
                LastName = "Doe",
                EmailId = "john@test.com",
                PANCardNo = "ABCDE1234F"
            };

            Assert.DoesNotThrow(() => user.CreateUser(newUser));
        }
    }
}
