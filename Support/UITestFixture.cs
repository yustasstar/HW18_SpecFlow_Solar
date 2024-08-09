using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HW18_SpecFlow.Support
{
    [Parallelizable(ParallelScope.Self)]
    [Binding]
    internal class UITestFixture
    {
        public static IPage? Page { get; private set; }
        private static IBrowser? browser;
        internal static string baseUrl = "https://solartechnology.com.ua/shop/";

        [BeforeFeature(Order = 1)]
        public static async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1885, Height = 945 },
            });

            Page = await context.NewPageAsync();
            Page.SetDefaultTimeout(15000);
            //Page.PauseAsync();
        }

        [AfterFeature]
        public static async Task Teardown()
        {
            if (Page != null) { await Page.CloseAsync(); }
            if (browser != null) { await browser.CloseAsync(); }
        }
    }
}