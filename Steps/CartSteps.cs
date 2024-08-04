using HW18_SpecFlow.PageObjects;
using HW18_SpecFlow.Support;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace HW18_SpecFlow.Steps
{
    [Binding]
    internal sealed class CartSteps : UITestFixture
    {
        internal static CartPage _CartPage;

        [BeforeScenario("@ShopPageSetup")]
        public static void ShopPageBeforeScenario()
        {
            _CartPage = new CartPage(Page);
        }

        [When(@"I am on the '([^']*)' page see heading '([^']*)'")]
        public async Task WhenIAmOnThePageSee(string pageUrl, string text)
        {
            await _CartPage.VerifyPageUrl($"{baseUrl}/{pageUrl}");
            await _CartPage.VerifyHeadingText(text);
        }
    }
}
