using HW18_SpecFlow.Support;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using System.Linq;

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

        #region Test DATA:
        //Locators:

        #endregion

        public async Task VerifyPageUrl(string testPageUrl)
        {
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

            Assert.That(page.Url, Is.EqualTo(testPageUrl));
        }

        public async Task VerifyHeadingVisible(string heading)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = heading })).ToBeVisibleAsync();
        }
    }
}

