using HW18_SpecFlow.PageObjects;
using HW18_SpecFlow.Support;
//using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace HW18_SpecFlow.Steps
{
    [Binding]
    internal sealed class ShopSteps : UITestFixture
    {
        internal static ShopPage _ShopPage;

        [BeforeScenario("@PageSetup")]
        public static void ShopPageBeforeScenario()
        {
            _ShopPage = new ShopPage(Page);
        }

        //Given (Arrange):

        [Given(@"I am on '([^']*)' page")]
        public async Task GivenGoToPage(string pageUrl)
        {
            await _ShopPage.GoToPageURL($"{baseUrl}/{pageUrl}");
        }

        //When (Act):

        [When(@"I click on '([^']*)' tab")]
        public async Task WhenIClickOnTab(string tabName)
        {
            await _ShopPage.ClickOnTabLink(tabName);
        }

        [When(@"I click on Filter button")]
        public async Task WhenIClickOnFilterButton()
        {
            await _ShopPage.ClickOnFilterButton();
        }

        [When(@"I click on '([^']*)' checkbox")]
        public async Task WhenIClickOnFilterCheckbox(string filterValue)
        {
            await _ShopPage.VerifyFilterChecked(filterValue);
        }

        [When(@"I add '([^']*)' to the Cart")]
        public async Task WhenIAddProductToTheCart(string product)
        {
            await _ShopPage.AddSpecifiedProductToCart(product);
        }

        [When(@"I click '([^']*)' button")]
        public async Task WhenIClickPopupButton(string buttonName)
        {
            await _ShopPage.ClickLinkButton(buttonName);
            await _ShopPage.VerifyAddPopupNotVisible();
        }

        [When(@"I click on '([^']*)' product holder")]
        public async Task WhenIClickOnProductHolder(string productName)
        {
            await _ShopPage.ClickSpecifiedProductHolder(productName);
        }

        //Then (Assert):

        [Then(@"I see '([^']*)' filtered products")]
        [Obsolete]
        public async Task ThenISeeProducts(string filterValue)
        {
            await _ShopPage.VerifyFilteredProducts(filterValue);
        }

        [Then(@"I see '([^']*)' heading is displayed")]
        public async Task ThenHeadingIsDisplayed(string h1)
        {
            await _ShopPage.VerifyH1Visability(h1);
        }
    }
}
