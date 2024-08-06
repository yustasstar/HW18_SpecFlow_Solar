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
            Assert.That(productsList.Count, Is.GreaterThan(0), $"Products by locator {productTitleLocator} not found");

            bool isAllContainFilterValue = productsList.All(product => product.ToLower().Contains(filterValue.ToLower()));
            Assert.That(isAllContainFilterValue, Is.True, $"Not all Products contains the text {filterValue}");
        }

        public async Task AddSpecifiedProductToCart(string addProduct)
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
                    Assert.That(addToCartButton, Is.Not.Null, $"'Add to cart button' not found for product {addProduct}");

                    //Add specified product to the cart
                    if (addToCartButton != null)
                    {
                        await addToCartButton.ClickAsync();
                    }
                    await Assertions.Expect(addPopup).ToContainTextAsync($"{addProduct}");
                    await Assertions.Expect(addPopup).ToContainTextAsync($"Товар додано у кошик");

                    return;
                }
            }
            Assert.That(isProductFound, Is.True, $"Product '{addProduct}' is not found on the page");
        }

        public async Task ClickLinkButton(string buttonName)
        {
            var button = page.GetByRole(AriaRole.Link, new() { Name = $"{buttonName}" });
            await button.ClickAsync();
        }

        public async Task ClickSpecifiedProductHolder(string productName)
        {
            var productHolderLocator = "//*[contains(@class, 'card z-depth-1 hoverable')]";
            var products = await page.QuerySelectorAllAsync(productHolderLocator);
            Assert.That(products, Is.Not.Empty, "Products not found on the page");

            foreach (var product in products)
            {
                var productText = await product.InnerTextAsync();
                if (productText.ToLower().Contains(productName.ToLower()))
                {
                    await product.ClickAsync();
                    return;
                }
            }
            await Assertions.Expect(page.Locator("//*[contains(@class, 'availability')]")).ToBeVisibleAsync();
        }

        public async Task VerifyAddPopupNotVisible()
        {
            var addModal = page.Locator("//*[@id='cart-modal']");
            await Assertions.Expect(addModal).Not.ToBeVisibleAsync();
        }
    }
}

