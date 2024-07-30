using HW18_SpecFlow.PageObjects;
using HW18_SpecFlow.Support;
using Microsoft.Playwright;

namespace HW18_SpecFlow.Steps
{
    [Binding]
    public sealed class ShopSteps
    {
        public static ShopPage _ShopPage;
        private static IPage page;

        [BeforeFeature("@WebPageLogin")]
        public static void FirstBeforeScenario()
        {
            _ShopPage = new ShopPage(page);
        }

        [Given(@"GoTo Shop Page")]
        public async Task GivenGoToShopPage()
        {
            await _ShopPage.GoToTestPageURL();
        }


        [When(@"Shop Page is loaded")]
        public async Task WhenShopPageIsLoaded()
        {
            await _ShopPage.WaitForUrlLoading();
        }

        [Then(@"""([^""]*)"" Heading is displayed")]
        public async Task ThenHeadingIsDisplayed(string heading)
        {
            await _ShopPage.IsPageH1Visible(heading);
        }

    }
}
