using System;
using Api.Controllers;
using Common.Interfaces;
using Data.Repository;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class EmailMessageRepositoryTest
    {
        private Mock<IEmailMessageRepository> _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new Mock<IEmailMessageRepository>();
        }

        [Test]
        public void EmailMessageRepositoryShouldThrowExceptionIfDbContextIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailMessageRepository(null));
        }
    }
}