using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq;
using System.Text.RegularExpressions;
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
        private readonly string  productTitleLocator = "//*[contains(@class, 'prod-title')]";
        private readonly string productRowLocator = "//*[contains(@class, 'cart-product row')]";
        private readonly string removeBtnLocator = "//*[starts-with(@class, 'remove-from-cart')]";

        public async Task VerifyPageUrl(string testPageUrl)
        {
            await page.WaitForURLAsync(testPageUrl);
        }

        public async Task VerifyHeadingVisible(string heading)
        {
            var headingLocator = page.GetByRole(AriaRole.Heading, new() { Name = heading });
            await Assertions.Expect(headingLocator).ToBeVisibleAsync();
        }

        public async Task VerifyProductAddedToCart(string addProductName)
        {
            var products = await page.Locator(productTitleLocator).AllInnerTextsAsync();
            bool productFound = products.Any(p => p.Contains(addProductName));
            if (productName.ToLower().Contains(addProduct.ToLower()))
            {
                var addToCartButton = await productCard.QuerySelectorAsync(addToCartBtn);
                await addToCartButton.ClickAsync();
                return;
            }
            //Assert.That(productFound, Is.True, $"{addProductName} is not in the cart");
            await Assertions.Expect(page.GetByText($"{addProductName}", new() { Exact = true })).ToBeVisibleAsync();
        }


        public async Task RemoveProductFromCart(string removeProductName)
        {
            var products = await page.QuerySelectorAllAsync(productRowLocator);
            Assert.That(products, Is.Not.Empty, "No products in the cart");

            foreach (var product in products)
            {
                var productName = await product.InnerTextAsync();
                if (productName.ToLower().Contains(removeProductName.ToLower()))
                {
                    var removeFromCartBtn = await product.QuerySelectorAsync(removeBtnLocator);
                    await removeFromCartBtn.ClickAsync();
                    return;
                }
            }
        }

        public async Task VerifyProductDeletedFromCart(string removedProduct)
        {
            await Assertions.Expect(page.GetByText("Товар видалено з кошика")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText($"{removedProduct}")).Not.ToBeVisibleAsync();
        }
    }
}

