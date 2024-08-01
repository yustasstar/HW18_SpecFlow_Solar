using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace HW18_SpecFlow.PageObjects
{
    [Binding]
    public class ShopPage
    {
        private readonly IPage page;
        private readonly string testPageUrl = "https://solartechnology.com.ua/shop";

        public ShopPage(IPage page)
        {
            this.page = page;
        }

        #region Test DATA:
        #endregion

        public async Task GoToTestPageURL()
        {
            await page.GotoAsync(testPageUrl);
        }

        public async Task WaitForUrlLoading()
        {
            await page.WaitForURLAsync(testPageUrl);
        }

        public async Task IsPageHeadingVisible(string heading)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = heading })).ToBeVisibleAsync();
        }
        public async Task CLickToInvertorsLink(string linkName)
        {
            await page.GetByRole(AriaRole.Link, new() { Name = linkName }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Сонячні інвертори" })).ToBeVisibleAsync();
        }

    }
}
