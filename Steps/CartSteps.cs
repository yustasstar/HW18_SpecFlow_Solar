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

        //Given (Arrange):


        //When (Act):


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
    }
}
