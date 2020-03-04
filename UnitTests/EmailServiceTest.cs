using System;
using System.Threading.Tasks;
using Common.Enums;
using Common.Interfaces;
using Moq;
using NUnit.Framework;
using Services;

namespace UnitTests
{
    [TestFixture]
    public class EmailServiceTest
    {
        private IEmailService _sut;
        private Mock<IEmailMessageRepository> _emailMessagesRepositoryMock;
        [SetUp]
        public void Setup()
        {
            _emailMessagesRepositoryMock = new Mock<IEmailMessageRepository>();
            _sut = new EmailService(_emailMessagesRepositoryMock.Object);
        }

        [Test]
        public void EmailService_ShouldThrowExceptionIfEmailRepositoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailService(null));
        }

        [Test]
        public async Task EmailService_ShouldReturnStatusNoneIfEmailNotExist()
        {
            _emailMessagesRepositoryMock.Setup(_ => _.GetById(It.IsAny<Guid>())).ReturnsAsync(() => null);

            var result = await _sut.GetStatusById(new Guid());

            Assert.AreEqual(EmailStatus.None, result);
        }

    }
}