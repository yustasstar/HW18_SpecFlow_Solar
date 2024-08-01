using HW18_SpecFlow.PageObjects;
using HW18_SpecFlow.Support;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace HW18_SpecFlow.Steps
{
    [Binding]
    internal sealed class ShopSteps : Hooks
    {
        internal static ShopPage _ShopPage;

        [BeforeScenario("@WebPage")]
        public static void FirstBeforeScenario()
        {
            _ShopPage = new ShopPage(Page);
        }


        [Given(@"GoTo Shop page")]
        public async Task GivenGoToShopPage() => await _ShopPage.GoToTestPageURL();

        [When(@"Shop page is loaded")]
        public async Task WhenShopPageIsLoaded() => await _ShopPage.WaitForUrlLoading();

        [Then(@"""([^""]*)"" Heading is displayed")]
        public async Task ThenHeadingIsDisplayed(string heading) => await _ShopPage.IsPageH1Visible(heading);
    }
}
