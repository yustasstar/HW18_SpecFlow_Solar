using HW18_SpecFlow.Support;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using System.Linq;

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

        public async Task GoToPageURL(string pageUrl)
        {
            await page.GotoAsync(pageUrl);

            try
            {
                await page.WaitForURLAsync(pageUrl);
            }
            catch (PlaywrightException e)
            {
                if (e.Message.Contains("crash"))
                {
                    Console.WriteLine("Page crashed: " + e.Message);
                }
            }
        }

        public async Task VerifyH1Visability(string h1)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = h1, Level = 1 })).ToBeVisibleAsync();
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
            var productTitleLocator = "//*[@class[starts-with(., 'list-product-title')]]";
            var allProducts = await page.Locator(productTitleLocator).AllInnerTextsAsync();
            var productsList = allProducts.ToList();
            Assert.That(productsList.Count, Is.GreaterThan(0), $"Products by filter {filterValue} not found");

            bool isListContainFilterValue = productsList.All(product => product.ToLower().Contains(filterValue.ToLower()));
            Assert.That(isListContainFilterValue, Is.True, $"Not all Products contains the text {filterValue}");
        }

        public async Task AddProductToCart(string addProduct)
        {
            var productHolderLocator = "//*[contains(@class, 'card z-depth-1 hoverable')]";
            var addToCartBtnLocator = "//*[@class[starts-with(., 'add-product-to-cart')]]";
            var addPopup = page.Locator("//*[@id='cart-modal']");

            // Get all product holders on the page
            var productCards = await page.QuerySelectorAllAsync(productHolderLocator);
            Assert.That(productCards, Is.Not.Empty, "Products not found on the page");

            // Iterate through each product holder to find the {addProduct}
            bool isProductFound = false; // To track if product is found
            foreach (var productCard in productCards)
            {
                var productName = await productCard.InnerTextAsync();
                if (productName.ToLower().Contains(addProduct.ToLower()))
                {
                    isProductFound = true;
                    var addToCartButton = await productCard.QuerySelectorAsync(addToCartBtnLocator);
                    Assert.That(addToCartButton, Is.Not.Null, $"Add to cart button not found for product {addProduct}");

                    //Add specified product to the cart
                    await addToCartButton.ClickAsync();

                    await Assertions.Expect(addPopup).ToContainTextAsync($"{addProduct}");
                    await Assertions.Expect(addPopup).ToContainTextAsync($"Товар додано у кошик");

                    return;
                }
            }
            // Assert that the product was found and processed
            Assert.That(isProductFound, Is.True, $"Product '{addProduct}' is not found on the page");
        }

        public async Task ClickLinkButton(string buttonName)
        {
            var linkButton = page.GetByRole(AriaRole.Link, new() { Name = $"{buttonName}" });
            await linkButton.ClickAsync();
        }

        public async Task VerifyPopupClosed()
        {
            var addModal = page.Locator("//*[@id='cart-modal']");
            await Assertions.Expect(addModal).Not.ToBeVisibleAsync();
        }
    }
}

