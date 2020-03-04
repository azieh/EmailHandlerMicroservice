using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Moq;
using NUnit.Framework;
using Services;

namespace UnitTests
{
    [TestFixture]
    public class SmtpServiceTest
    {
        [SetUp]
        public void Setup()
        {
            _sut = new SmtpService(new SmtpClient());
        }

        private ISmtpService _sut;

        [Test]
        public void SmtpService_ShouldThrowExceptionIfSmtpClientIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SmtpService(null));
        }
        [Test]
        public void SmtpService_GenerateMailMessage_ShouldThrowExceptionIfSenderIsNotValid()
        {
            var message = new EmailMessage() { Sender = "test", To = "poczta@o2.pl", Subject = "Subject"};
            Assert.Throws<ArgumentException>(() => _sut.GenerateMailMessage(message));
        }

        [Test]
        public void SmtpService_GenerateMailMessage_ShouldThrowExceptionIfToIsNotValid()
        {
            var message = new EmailMessage() { Sender = "poczta@o2.pl", To = "test", Subject = "Subject" };
            Assert.Throws<ArgumentException>(() => _sut.GenerateMailMessage(message));
        }

        [Test]
        public void SmtpService_GenerateMailMessage_ShouldThrowExceptionIfSubjectIsEmpty()
        {
            var message = new EmailMessage() { Sender = "poczta@o2.pl", To = "poczta@o2.pl", Subject = "" };
            Assert.Throws<ArgumentException>(() => _sut.GenerateMailMessage(message));
        }
    }
}