using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace HW18_SpecFlow.PageObjects
{
    [Binding]
    internal class CartPage
    {
        private readonly IPage page;

        public CartPage(IPage page)
        {
            this.page = page;
        }
        //Locators:
        private readonly string productTitleLocator = "//*[@class='prod-title']";
        private readonly string productRowLocator = "//*[contains(@class, 'cart-product row')]";
        private readonly string removeBtnLocator = "//*[starts-with(@class, 'remove-from-cart')]";

        public async Task VerifyPageUrl(string pageUrl)
        {
            await page.WaitForURLAsync(pageUrl);
        }

        public async Task VerifyHeadingVisible(string heading)
        {
            var headingLocator = page.GetByRole(AriaRole.Heading, new() { Name = heading });
            await Assertions.Expect(headingLocator).ToBeVisibleAsync();
        }

        public async Task VerifyProductAddedToCart(string productName)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = productName })).ToBeVisibleAsync();
        }

        public async Task RemoveProductFromCart(string productName)
        {
            await page.GetByRole(AriaRole.Listitem).Filter(new() { Has = page.GetByRole(AriaRole.Link, new() { Name = productName })}).Locator(removeBtnLocator).ClickAsync();
        }

        public async Task VerifyProductDeletedFromCart(string product)
        {
            await Assertions.Expect(page.GetByText("Товар видалено з кошика")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText($"{product}")).Not.ToBeVisibleAsync();
        }
    }
}

