using HW18_SpecFlow.Support;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace HW18_SpecFlow.PageObjects
{
    [Binding]
    internal class ShopPage
    {
        private readonly IPage page;

        public ShopPage(IPage page)
        {
            this.page = page;
        }

        #region Test DATA:
        //Locators:

        #endregion

        public async Task GoToPageURL(string testPageUrl)
        {
            await page.GotoAsync(testPageUrl);

            try
            {
                await page.WaitForURLAsync(testPageUrl);
            }
            catch (PlaywrightException e)
            {
                if (e.Message.Contains("crash"))
                {
                    Console.WriteLine("Page crashed: " + e.Message);
                }
            }
        }

        public async Task VerifyH1Visability(string heading)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = heading, Level = 1 })).ToBeVisibleAsync();
        }

        public async Task ClickOnTabLink(string tabName)
        {
            await page.GetByRole(AriaRole.Link, new() { Name = tabName }).ClickAsync();
        }

        public async Task ClickOnFilterButton()
        {
            var filterButtonLocator = "//*[contains(@class, 'filter-button')]";
            var filterButton = page.Locator(filterButtonLocator);

            await filterButton.ClickAsync();
        }

        public async Task VerifyFilterChecked(string filterValue)
        {
            var filterCheckboxLocator = $"//span[text()='{filterValue}']";
            var filter = page.Locator(filterCheckboxLocator);

            await filter.CheckAsync();
            await Assertions.Expect(filter).ToBeCheckedAsync();
        }

        [Obsolete]
        public async Task VerifyFilteredProducts(string filterValue)
        {
            await page.WaitForNavigationAsync();

            var productTitle = page.Locator("//*[@class[starts-with(., 'list-product-title')]]");
            var allProducts = await productTitle.AllInnerTextsAsync();
            var productsList = allProducts.ToList();
            Assert.That(productsList.Count, Is.GreaterThan(0), $"Products by filter {filterValue} not found");

            bool isAllContainFilterValue = productsList.All(product => product.ToLower().Contains(filterValue.ToLower()));
            Assert.That(isAllContainFilterValue, Is.True, $"Not all Products contains the text {filterValue}");
        }
        public async Task AddProductToCart(string product)
        {
            await page.GetByRole(AriaRole.Link, new() { Name = product }).ClickAsync();
        }
    }
}
