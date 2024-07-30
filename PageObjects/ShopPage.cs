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
    public class ShopPage
    {
        private readonly IPage page;
        public ShopPage(IPage page)
        {
            this.page = page;
        }

        #region Test DATA:
        private readonly string testPageUrl = "https://solartechnology.com.ua/shop";
        //Locators:
        //private readonly string tableLocator = ".ReactTable";
        //private readonly string rowLocator = ".rt-tr-group";
        //private readonly string headerLocator = ".rt-th";
        //private readonly string cellLocator = ".rt-td";
        //private readonly string searchLocator = "Type to search";
        //private readonly string addPopupLocator = ".modal-content";
        #endregion

        #region Page
        public async Task GoToTestPageURL()
        {
            await page.GotoAsync(testPageUrl);
        }
        public async Task WaitForUrlLoading()
        {
            await page.WaitForURLAsync(testPageUrl);
        }

        public async Task IsPageH1Visible(string heading)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = heading })).ToBeVisibleAsync();
        }
        #endregion
    }
}
