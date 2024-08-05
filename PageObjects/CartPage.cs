﻿using HW18_SpecFlow.Support;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using System.Linq;
using System.Net.Http.Headers;

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
            //await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Товари у кошику" })).ToBeVisibleAsync();
            //await Assertions.Expect(page.GetByText($"{addProductName}")).ToBeVisibleAsync();

            var productTitleLocator = "//*[contains(@class, 'prod-title')]";
            var allProducts = await page.Locator(productTitleLocator).AllInnerTextsAsync();
            var productsList = allProducts.ToList();
            Assert.That(productsList.Count, Is.GreaterThan(0), $"Products by locator {productTitleLocator} not found in the cart");

            bool isAnyContainProductValue = productsList.Any(product => product.ToLower().Contains(addProductName.ToLower()));
            Assert.That(isAnyContainProductValue, Is.True, $" No product '{addProductName}' in the cart");
        }

        public async Task RemoveProductFromCart(string removeProductName)
        {
            var productRowLocator = "//*[contains(@class, 'cart-product row')]";
            var removeBtnLocator = "//*[starts-with(@class, 'remove-from-cart')]";
            var products = await page.QuerySelectorAllAsync(productRowLocator);
            Assert.That(products, Is.Not.Empty, "No products in the cart");

            foreach (var product in products)
            {
                var productName = await product.InnerTextAsync();
                if (productName.ToLower().Contains(removeProductName.ToLower()))
                {
                    var removeFromCartBtn = await product.QuerySelectorAsync(removeBtnLocator);
                    if (removeFromCartBtn != null)
                    {
                        await removeFromCartBtn.ClickAsync();
                    }
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

