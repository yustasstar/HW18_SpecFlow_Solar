using HW18_SpecFlow.PageObjects;
using HW18_SpecFlow.Support;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace HW18_SpecFlow.Steps
{
    [Binding]
    internal sealed class ShopSteps : UITestFixture
    {
        internal static ShopPage _ShopPage;

        [BeforeScenario("@ShopPageSetup")]
        public static void ShopPageBeforeScenario()
        {
            _ShopPage = new ShopPage(Page);
        }

        [Given(@"I am on '([^']*)' page")]
        public async Task GivenGoToPage(string pageUrl)
        {
            await _ShopPage.GoToPageURL($"{baseUrl}/{pageUrl}");
        }

        [Then(@"I see '([^']*)' is displayed")]
        public async Task ThenHeadingIsDisplayed(string h1)
        {
            await _ShopPage.VerifyH1Visability(h1);
        }

        [When(@"I click on '([^']*)' tab")]
        public async Task WhenIClickOnLink(string tabName)
        {
            await _ShopPage.ClickOnTabLink(tabName);
        }

        [When(@"I click on Filter button")]
        public async Task WhenIClickOnFilterButton()
        {
            await _ShopPage.ClickOnFilterButton();
        }

        [When(@"I check '([^']*)' filter")]
        public async Task WhenIClickOnFilter(string filterValue)
        {
            await _ShopPage.VerifyFilterChecked(filterValue);
        }

        [Then(@"I see '([^']*)' products")]
        [Obsolete]
        public async Task ThenISeeProducts(string filterValue)
        {
            await _ShopPage.VerifyFilteredProducts(filterValue);
        }

        [When(@"I add '([^']*)' in the Cart")]
        public async Task WhenIAddInTheCart(string product)
        {
            await _ShopPage.AddProductToCart(product);
        }
    }
}
