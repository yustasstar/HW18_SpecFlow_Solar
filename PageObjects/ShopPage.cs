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
        //Locators:
        private readonly string addPopup = "//*[@id='cart-modal']";
        private readonly string prodHolder = "//div[contains (@class, 'prod-holder')]";
        private readonly string addToCartBtn = "//*[@class[starts-with(., 'add-product-to-cart')]]";
        private readonly string filterBtn = "//*[contains(@class, 'filter-button')]";
        private readonly string pageItemsCounter = "//ul[@class = 'pagination']";


        public async Task GoToPageURL(string pageUrl)
        {
            await page.GotoAsync(pageUrl);
        }

        public async Task VerifyH1Visability(string h1)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = h1, Level = 1 })).ToBeVisibleAsync();
        }

        public async Task ClickOnFilterButton()
        {
            await page.Locator(filterBtn).ClickAsync();
        }

        public async Task SelectCheckbox(string filterValue)
        {
            var filterCheckbox = page.Locator($"//span[text()='{filterValue}']");
            await filterCheckbox.CheckAsync();
            await Assertions.Expect(filterCheckbox).ToBeCheckedAsync();
            await page.WaitForNavigationAsync();
        }

        public async Task ClickLinkButton(string buttonName)
        {
            await page.GetByRole(AriaRole.Link, new() { Name = $"{buttonName}" }).ClickAsync();
        }

        public async Task<(int productCount, int pageCount)> GetCountOfItems()
        {
            var productCount = await page.Locator(prodHolder).CountAsync();
            var pageCount = await page.Locator(pageItemsCounter).GetByRole(AriaRole.Listitem).CountAsync();
            return (productCount, pageCount);
        }

        public async Task AddProductToCart(string productName)
        {
            await page.Locator(prodHolder).Filter(new() { Has = page.GetByRole(AriaRole.Link, new() { Name = productName }) }).Locator(addToCartBtn).ClickAsync();
        }

        public async Task VerifyProductAdded(string addProduct)
        {
            await Assertions.Expect(page.Locator($"{addPopup}")).ToContainTextAsync($"Товар додано у кошик");
            await Assertions.Expect(page.GetByText($"{addProduct}", new() { Exact = true })).ToBeVisibleAsync();
        }

        public async Task VerifyAddPopupNotVisible()
        {
            await Assertions.Expect(page.Locator($"{addPopup}")).Not.ToBeVisibleAsync();
        }

        public async Task ClickSpecifiedProductHolder(string productName)
        {
            await page.Locator(prodHolder).Filter(new() { Has = page.GetByRole(AriaRole.Link, new() { Name = productName }) }).ClickAsync();
        }
    }
}

