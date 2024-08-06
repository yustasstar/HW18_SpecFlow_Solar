using HW18_SpecFlow.PageObjects;
using HW18_SpecFlow.Support;
//using Microsoft.Playwright;
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
        public async Task WhenIRemoveFromTheCart(string removeProduct)
        {
            await _CartPage.RemoveProductFromCart(removeProduct);
        }

        //Then (Assert):

        [Then(@"I am on the '([^']*)' page")]
        public async Task WhenIAmOnThePage(string pageUrl)
        {
            await _CartPage.VerifyPageUrl($"{baseUrl}/{pageUrl}");
        }

        [Then(@"I see heading '([^']*)'")]
        public async Task WhenISeeHeading(string heading)
        {
            await _CartPage.VerifyHeadingVisible(heading);
        }

        [Then(@"I see '([^']*)' in the Cart")]
        public async Task ThenISeeProductInTheCart(string addedProduct)
        {
            await _CartPage.VerifyProductAddedToCart(addedProduct);
        }

        [Then(@"I do not see '([^']*)' in the Cart")]
        public async Task ThenIDoNotSeeInTheCart(string removedProduct)
        {
            await _CartPage.VerifyProductDeletedFromCart(removedProduct);
        }
    }
}
