using HW18_SpecFlow.PageObjects;
using HW18_SpecFlow.Support;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

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
        public async Task GivenIAmOnPage(string pageUrl)
        {
            await _ShopPage.GoToPageURL($"{baseUrl}shop/{pageUrl}");
        }

        //When (Act):

        [When(@"I see '([^']*)'")]
        public async Task WhenISee(string h1)
        {
            await _ShopPage.VerifyH1Visability(h1);
        }


        [When(@"I add '([^']*)' to the Cart")]
        public async Task WhenIAddProductToTheCart(string product)
        {
            await _ShopPage.AddProductToCart(product);
            await _ShopPage.VerifyProductAdded(product);
        }

        [When(@"I click '([^']*)' button")]
        public async Task WhenIClickPopupButton(string buttonName)
        {
            await _ShopPage.ClickLinkButton(buttonName);
        }

        [When(@"I continue shoping")]
        public async Task WhenIContinueShoping()
        {
            await _ShopPage.VerifyAddPopupNotVisible();
        }


        //[When(@"I click on '([^']*)' product holder")]
        //public async Task WhenIClickOnProductHolder(string productName)
        //{
        //    await _ShopPage.ClickSpecifiedProductHolder(productName);
        //}



        //Then (Assert):

        [Then(@"I see filter works by '([^']*)'")]
        public async Task ThenISeeFilterWorksBy(string filterValue)
        {
            var resultBefore = await _ShopPage.GetCountOfItems();
            await _ShopPage.ClickOnFilterButton();
            await _ShopPage.SelectCheckbox(filterValue);

            var resultAfter = await _ShopPage.GetCountOfItems();
            Assert.That(resultAfter, Is.LessThan(resultBefore),
                $"Expected the count of items after filtering should be less than before. Before: {resultBefore}, After: {resultAfter}");
        }
    }
}
