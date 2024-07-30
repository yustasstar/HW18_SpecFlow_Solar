using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HW18_SpecFlow.Support
{
    [Binding]
    [Parallelizable(ParallelScope.Self)]
    internal class Hooks
    {
        public static IPage? Page { get; private set; }
        private static IBrowser? browser;

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
                ViewportSize = new ViewportSize
                {
                    Width = 1890,
                    Height = 950
                }
            });

            Page = await context.NewPageAsync();
        }

        [AfterFeature]
        public static async Task Teardown()
        {
            if (Page != null)
            {
                await Page.CloseAsync();
            }

            if (browser != null)
            {
                await browser.CloseAsync();
            }
        }
    }
}