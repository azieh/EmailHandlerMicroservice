using System;
using Data.Repository;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class EmailMessageRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmailMessageRepositoryShouldThrowExceptionIfDbContextIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailMessageRepository(null));
        }
    }
}