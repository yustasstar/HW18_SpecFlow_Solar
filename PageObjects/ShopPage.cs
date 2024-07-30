using HW18_SpecFlow.Support;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18_SpecFlow.PageObjects
{
    [Binding]
    internal class ShopPage
    {
        private readonly IPage Page;
        private readonly string testPageUrl = "https://solartechnology.com.ua/shop";

        public ShopPage(IPage page)
        {
            Page = page;
        }

        #region Test DATA:
        //Locators:
        //private readonly string tableLocator = ".ReactTable";
        #endregion

        #region Page
        public async Task GoToTestPageURL()
        {
            await Page.GotoAsync(testPageUrl);
        }
        public async Task WaitForUrlLoading()
        {
            await Page.WaitForURLAsync(testPageUrl);
        }

        public async Task IsPageH1Visible(string heading)
        {
            await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { Name = heading })).ToBeVisibleAsync();
        }
        #endregion
    }
}
