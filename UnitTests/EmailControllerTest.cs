using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Controllers;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class EmailControllerTest
    {
        [SetUp]
        public void Setup()
        {
            _emailServiceMock = new Mock<IEmailService>();
            _sut = new EmailController(_emailServiceMock.Object);
        }

        private EmailController _sut;
        private Mock<IEmailService> _emailServiceMock;

        [Test]
        public async Task EmailController_GetAll_ShouldReturn200Ok()
        {
            _emailServiceMock.Setup(_ => _.GetAllAsync()).ReturnsAsync(() => new List<EmailMessage>());

            var result = await _sut.GetAllMessages();

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task EmailController_GetMessageDetails_ShouldReturn200Ok()
        {
            _emailServiceMock.Setup(_ => _.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(() => new EmailMessage());

            var result = await _sut.GetMessageDetails(new Guid());

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task EmailController_GetMessageDetails_ShouldReturn404IfEmailNotExist()
        {
            _emailServiceMock.Setup(_ => _.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(() => null);

            var result = await _sut.GetMessageDetails(new Guid());

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task EmailController_GetMessageStatus_ShouldReturn200Ok()
        {
            _emailServiceMock.Setup(_ => _.GetStatusByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(() => EmailStatus.Pending);

            var result = await _sut.GetMessageStatus(new Guid());

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task EmailController_GetMessageStatus_ShouldReturn404IfEmailNotExist()
        {
            _emailServiceMock.Setup(_ => _.GetStatusByIdAsync(It.IsAny<Guid>())).ReturnsAsync(() => EmailStatus.None);

            var result = await _sut.GetMessageStatus(new Guid());

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task EmailController_PostMessage_ShouldReturn200Ok()
        {
            var uniqueGuid = Guid.NewGuid();
            _emailServiceMock.Setup(_ => _.AddToQueueAsync(It.IsAny<NewEmailMessage>())).ReturnsAsync(() => uniqueGuid);

            var result = await _sut.PutMessage(new NewEmailMessage());

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(uniqueGuid, okResult.Value);
        }

        [Test]
        public async Task EmailController_SendAllPendingEmails_ShouldReturn200Ok()
        {
            var uniqueGuidList = new List<Guid> {Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()};

            _emailServiceMock.Setup(_ => _.SendAllPendingEmailsAsync()).ReturnsAsync(() => uniqueGuidList);

            var result = await _sut.SendAllPendingEmails();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(uniqueGuidList, okResult.Value);
        }

        [Test]
        public void EmailController_ShouldThrowExceptionIfEmailRepositoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailController(null));
        }
    }
}