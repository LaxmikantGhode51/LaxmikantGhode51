//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Playwright;

//namespace PlaywrightDemo.Test
//{
//    public class EaaSomee
//    {
//        private IPlaywright _playwright;
//        private IBrowser _browser;
//        private IBrowserContext _context;
//        private IPage _page;
//        private LoginAssertions _assertions;


//        [Test]
//        public async Task SampleTest()
//        {
//            _playwright = await Playwright.CreateAsync();
//            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
//            {
//                Headless = false // Set to true to run tests in headless mode
//            });



//            _context = await _browser.NewContextAsync();
//            _page = await _context.NewPageAsync();
//            await _page.GotoAsync("http://eaapp.somee.com/");
           
//            await _page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
//            await _page.GetByLabel("UserName").ClickAsync();
//            var usernameField = _page.GetByLabel("UserName");
//            Assert.IsTrue(await usernameField.IsVisibleAsync(), "Username field is not visible");

//            await _page.GetByLabel("UserName").FillAsync("laxmikant");
//            await _page.GetByLabel("Password").ClickAsync();
//            var passwordField = _page.GetByLabel("Password");
//            Assert.IsTrue(await passwordField.IsVisibleAsync(), "Password field is not visible");

//            await _page.GetByLabel("Password").FillAsync("ghode");
//            await _page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
//            await _page.GetByRole(AriaRole.Heading, new() { Name = "Login." }).ClickAsync();
//            await _page.GetByRole(AriaRole.Img).ClickAsync();

//            await _page.PauseAsync();




//        }
//    }

//}
