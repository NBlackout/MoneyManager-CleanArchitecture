using AutoFixture;
using AutoFixture.Xunit2;
using MoneyManager.Test.Utilities.AutoFixture.Specimens;

namespace MoneyManager.Test.Utilities.AutoFixture
{
    public class ExtendedAutoDataAttribute : AutoDataAttribute
    {
        public ExtendedAutoDataAttribute()
            : base(FixtureFactory)
        {
        }

        private static IFixture FixtureFactory() => new Fixture().Customize(new FixtureCustomizer());

        private class FixtureCustomizer : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                RegisterDomainSpecimenBuilders();

                void RegisterDomainSpecimenBuilders()
                {
                    fixture.Customizations.Add(new AccountBuilder());
                }
            }
        }
    }
}
