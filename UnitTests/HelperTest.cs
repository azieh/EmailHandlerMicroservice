using System.Collections.Generic;
using Common.Utilities;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class HelperTest
    {
        [TestCase("wasielewski.adrian")]
        [TestCase("wasielewski.adrian@")]
        [TestCase("@o2.pl")]
        [TestCase("sdfdsfdsf")]
        [TestCase("")]
        public void StringEmailIsNotValid(string email)
        {
            Assert.IsFalse(email.IsEmail());
        }

        [TestCase("")]
        public void ObjectEmailIsNotValid(object email)
        {
            Assert.IsFalse(email.IsEmail());
        }

        [TestCase("wasielewski.adrian@o2.pl")]
        public void StringEmailIsValid(string email)
        {
            Assert.IsTrue(email.IsEmail());
        }

        [TestCase("wasielewski.adrian@o2.pl")]
        public void ObjectEmailIsValid(object email)
        {
            Assert.IsTrue(email.IsEmail());
        }

        [Test]
        public void ObjectEmailListIsNotValid()
        {
            var list = new List<string> {"wasielewski.adrian@o2.pl", "wasielewski.adrian"};
            Assert.IsFalse(list.IsEmailList());
        }

        [Test]
        public void ObjectEmailListIsValid()
        {
            var list = new List<string> {"wasielewski.adrian@o2.pl", "adrian.wasielewski@o2.pl"};
            Assert.IsTrue(list.IsEmailList());
        }
    }
}