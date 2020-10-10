using AutoFixture;
using AutoFixture.Kernel;
using MoneyManager.Domain;

namespace MoneyManager.Test.Utilities.AutoFixture.Specimens
{
    public class AccountBuilder : CustomSpecimenBuilder<Account>
    {
        protected override Account CreateSpecimen(object request, ISpecimenContext context)
        {
            var label = context.Create<string>();

            return new Account(label);
        }
    }
}
