using System;
using Api.Controllers;
using Common.Interfaces;
using Common.Utilities;
using Moq;
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

        [TestCase((object)"")]
        public void ObjectEmailIsNotValid(object email)
        {
            Assert.IsFalse(email.IsEmail());
        }
    }
}