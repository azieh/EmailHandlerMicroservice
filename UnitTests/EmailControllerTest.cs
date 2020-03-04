using System;
using Api.Controllers;
using Common.Interfaces;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class EmailControllerTest
    {
        private EmailController _sut;
        private Mock<IEmailMessageRepository> _emailMessagesRepositoryMock;
        [SetUp]
        public void Setup()
        {
            _emailMessagesRepositoryMock = new Mock<IEmailMessageRepository>();
        }

        [Test]
        public void EmailControllerShouldThrowExceptionIfEmailRepositoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailController(null));
        }

    }
}