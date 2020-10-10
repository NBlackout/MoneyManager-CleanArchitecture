using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using MoneyManager.Application.UnitTests.Ports;
using MoneyManager.Application.UseCases.GetAccounts;
using MoneyManager.Domain;
using MoneyManager.Test.Utilities.AutoFixture;
using Xunit;

namespace MoneyManager.Application.UnitTests
{
    public class GetAccountsUseCaseTests
    {
        private readonly GetAccountsUseCase instance;
        private readonly FakeAccountRepository accountRepository;

        public GetAccountsUseCaseTests()
        {
            accountRepository = new FakeAccountRepository();
            instance = new GetAccountsUseCase(accountRepository);
        }

        [Fact]
        public async Task NoExistingAccount_GivesNoResult()
        {
            IEnumerable<GetAccountsResult> accounts = await ActAsync();

            accounts.Should().BeEmpty();
        }

        [Theory, ExtendedAutoData]
        public async Task ExistingAccounts_GivesAllAccounts(Generator<Account> accountGenerator)
        {
            List<Account> accounts = accountGenerator.Take(2).ToList();
            accounts.ForEach(accountRepository.Add);

            IEnumerable<GetAccountsResult> accountResults = await ActAsync();

            IEnumerable<GetAccountsResult> expectedResults = accounts.Select(a => new GetAccountsResult { Label = a.Label });
            accountResults.Should().BeEquivalentTo(expectedResults);
        }

        private async Task<IEnumerable<GetAccountsResult>> ActAsync() => await instance.ExecuteAsync();
    }
}
