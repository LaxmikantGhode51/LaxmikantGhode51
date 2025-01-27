using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightDemo.Config;

namespace PlaywrightDemo.Driver
{
    public class PlaywrightDriver
    {
        public async Task<IPage> IniatializePlaywrightAsync(TestSettings testSettings)
        {
            var browserOption = new BrowserTypeLaunchOptions();
            browserOption.Headless = testSettings.Headless;
           // browserOption.DevTools = true;
            browserOption.SlowMo = 1500;
            browserOption.Channel = "chrome";
            var playwrightDriver = await Playwright.CreateAsync();

            var browserContext = await playwrightDriver.Chromium.LaunchAsync();

            var page = await browserContext.NewPageAsync();
            await page.SetViewportSizeAsync(1920, 1080);
            await page.GotoAsync("http://www.eaapp.somee.com");
            return page;





        }
    }
}
