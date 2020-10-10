using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace MoneyManager.Domain.UnitTests
{
    public class AccountTests
    {
        [Fact]
        public void InvalidLabel_GivesError()
        {
            const string expectedMessage = "Account label should not be empty";

            var nullException = Assert.Throws<ArgumentException>(() => Act(null));
            var emptyException = Assert.Throws<ArgumentException>(() => Act(string.Empty));
            var whitespaceException = Assert.Throws<ArgumentException>(() => Act(" "));

            nullException.Message.Should().Be(expectedMessage);
            emptyException.Message.Should().Be(expectedMessage);
            whitespaceException.Message.Should().Be(expectedMessage);
        }

        [Theory, AutoData]
        public void ValidParameters_ProperlySetsMembers(string label)
        {
            Account instance = Act(label);

            instance.Label.Should().Be(label);
            instance.Balance.Should().Be(0m);
        }

        private static Account Act(string name) => new Account(name);
    }
}
