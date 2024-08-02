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

        [When(@"'([^']*)' page is loaded")]
        public async Task WhenPageIsLoaded(string pageUrl)
        {
            await _ShopPage.WaitForUrlLoading($"{baseUrl}/{pageUrl}");
        }

        [Then(@"I see '([^']*)' Heading is displayed")]
        public async Task ThenHeadingIsDisplayed(string heading)
        {
            await _ShopPage.VerifyH1Visability(heading);
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
    }
}
