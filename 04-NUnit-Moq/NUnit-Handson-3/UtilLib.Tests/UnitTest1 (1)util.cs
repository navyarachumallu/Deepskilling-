using NUnit.Framework;
using UtilLib;
using System;

namespace UtilLib.Tests
{
    public class Tests
    {
        private UtilLib.UrlHostNameParser parser;

        [SetUp]
        public void Setup()
        {
            parser = new UtilLib.UrlHostNameParser();
        }

        [TestCase("http://www.google.com", "www.google.com")]
        [TestCase("https://www.facebook.com", "www.facebook.com")]
        [TestCase("http://www.github.com", "www.github.com")]
        [TestCase("https://chat.openai.com", "chat.openai.com")]
        public void ParseHostName_ValidUrls_ReturnsHostName(string url, string expected)
        {
            string result = parser.ParseHostName(url);

            Assert.AreEqual(expected, result);
        }

        [TestCase("ftp://www.google.com")]
        [TestCase("smtp://mail.google.com")]
        [TestCase("file://C:/test.txt")]
        public void ParseHostName_InvalidProtocol_ThrowsFormatException(string url)
        {
            var ex = Assert.Throws<FormatException>(() => parser.ParseHostName(url));

            Assert.AreEqual("Url is not in correct format", ex.Message);
        }
    }
}
