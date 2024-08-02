using HW18_SpecFlow.Support;
using Microsoft.Playwright;
using NUnit.Framework;
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

        public async Task GoToPageURL(string testPageUrl)
        {
            await page.GotoAsync(testPageUrl);
        }

        public async Task WaitForUrlLoading(string testPageUrl)
        {
            try
            {
                // Attempt to perform actions on the page that might lead to a crash
                await page.WaitForURLAsync(testPageUrl);
            }
            catch (PlaywrightException e)
            {
                // Handle the crash gracefully
                if (e.Message.Contains("crash"))
                {
                    Console.WriteLine("Page crashed: " + e.Message);
                    // Add additional crash recovery logic here
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

        public async Task VerifyFilteredProducts(string filterValue)
        {
            var product = page.Locator("//*[@class[starts-with(., 'list-product-title')]]");
            var allProducts = await product.AllInnerTextsAsync();
            var productsList = allProducts.ToList();
            Assert.That(productsList.Count, Is.GreaterThan(0), $"Products by filter {filterValue} not found");

            bool allContainFilterValue = productsList.All(product => product.Contains(filterValue));
            Assert.That(allContainFilterValue, Is.True, $"Not all Products contains the text {filterValue}");
        }

    }
}
