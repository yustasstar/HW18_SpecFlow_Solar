using HW18_SpecFlow.PageObjects;
using HW18_SpecFlow.Support;
using TechTalk.SpecFlow;

namespace HW18_SpecFlow.Steps
{
    [Binding]
    internal sealed class CartSteps : UITestFixture
    {
        internal static CartPage _CartPage;

        [BeforeScenario("@PageSetup")]
        public static void ShopPageBeforeScenario()
        {
            _CartPage = new CartPage(Page);
        }

        //Given (Arrange):


        //When (Act):

        [When(@"I remove '([^']*)' from the Cart")]
        public async Task WhenIRemoveFromTheCart(string product)
        {
            await _CartPage.RemoveProductFromCart(product);
        }

        //Then(Assert) :

        [Then(@"I am on the '([^']*)' page")]
        public async Task ThenIAmOnThePage(string pageUrl)
        {
            await _CartPage.VerifyPageUrl($"{baseUrl}{pageUrl}");
        }

        [Then(@"I see heading '([^']*)'")]
        public async Task ThenISeeHeading(string heading)
        {
            await _CartPage.VerifyHeadingVisible(heading);
        }

        [Then(@"I see '([^']*)' in the Cart")]
        public async Task ThenISeeProductInTheCart(string product)
        {
            await _CartPage.VerifyProductAddedToCart(product);
        }

        [Then(@"I do not see '([^']*)' in the Cart")]
        public async Task ThenIDoNotSeeInTheCart(string product)
        {
            await _CartPage.VerifyProductDeletedFromCart(product);
        }
    }
}
