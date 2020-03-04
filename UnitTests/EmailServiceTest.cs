using System;
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
    public class EmailServiceTest
    {
        [SetUp]
        public void Setup()
        {
            _emailMessagesRepositoryMock = new Mock<IEmailMessageRepository>();
            _smtpServiceMock = new Mock<ISmtpService>();
            _sut = new EmailService(_emailMessagesRepositoryMock.Object, _smtpServiceMock.Object);
        }

        private IEmailService _sut;
        private Mock<IEmailMessageRepository> _emailMessagesRepositoryMock;
        private Mock<ISmtpService> _smtpServiceMock;

        [Test]
        public async Task EmailService_ShouldReturnStatusNoneIfEmailNotExist()
        {
            _emailMessagesRepositoryMock.Setup(_ => _.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(() => null);

            var result = await _sut.GetStatusByIdAsync(new Guid());

            Assert.AreEqual(EmailStatus.None, result);
        }

        [Test]
        public async Task EmailService_ShouldReturnStatusPending()
        {
            _emailMessagesRepositoryMock.Setup(_ => _.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(() => new EmailMessage {Status = EmailStatus.Pending});

            var result = await _sut.GetStatusByIdAsync(new Guid());

            Assert.AreEqual(EmailStatus.Pending, result);
        }

        [Test]
        public void EmailService_ShouldThrowExceptionIfEmailRepositoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailService(null, _smtpServiceMock.Object));
        }

        [Test]
        public void EmailService_ShouldThrowExceptionIfSmtpServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailService(_emailMessagesRepositoryMock.Object, null));
        }
    }
}