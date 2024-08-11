using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HW18_SpecFlow.Support
{
    [Parallelizable(ParallelScope.Self)]
    [Binding]
    internal class UITestFixture
    {
        public static IBrowserContext? Context { get; private set; }
        public static IPage? Page { get; private set; }
        private static IBrowser? browser;
        internal static string baseUrl = "https://solartechnology.com.ua/";

        [BeforeFeature(Order = 1)]
        public static async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            Context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1885, Height = 945 },
            });

            await Context.Tracing.StartAsync(new()
            {
                Title = TestContext.CurrentContext.Test.ClassName + "." + TestContext.CurrentContext.Test.Name,
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            Page = await Context.NewPageAsync();
            Page.SetDefaultTimeout(15000);
            //Page.PauseAsync();
        }

        [AfterFeature]
        public static async Task Teardown()
        {
            var failed = TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Error
           || TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Failure;

            if (Context != null)
            {
                await Context.Tracing.StopAsync(new()
                {
                    Path = failed ? Path.Combine(
                    TestContext.CurrentContext.WorkDirectory,
                    "playwright-traces",
                    $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
                ) : null,
                });
            }

            if (Page != null) { await Page.CloseAsync(); }
            if (browser != null) { await browser.CloseAsync(); }
        }
    }
}