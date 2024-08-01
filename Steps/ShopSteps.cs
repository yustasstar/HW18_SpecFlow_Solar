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

        [BeforeScenario("@ShopPage")]
        public static void FirstBeforeScenario()
        {
            _ShopPage = new ShopPage(Page);
        }


        [Given(@"I'm on Shop page")]
        public async Task GivenGoToShopPage() => await _ShopPage.GoToTestPageURL();

        [When(@"Shop page is loaded")]
        public async Task WhenShopPageIsLoaded() => await _ShopPage.WaitForUrlLoading();

        [Then(@"I see ""([^""]*)"" Heading is displayed")]
        public async Task ThenHeadingIsDisplayed(string heading) => await _ShopPage.IsPageHeadingVisible(heading);
        //________________________________

        [When(@"I click on ""([^""]*)"" link")]
        public async void WhenIClickOnLink(string linkName)
        {
            await _ShopPage.CLickToInvertorsLink(linkName);
        }

    }
}
