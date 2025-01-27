//using Microsoft.Playwright;
//using NUnit.Framework;
//using System.Threading.Tasks;

//public class LoginTests
//{
//    private IPage _page;
//    private LoginAssertions _assertions;

//    [SetUp]
//    public async Task Setup()
//    {
//        var playwright = await Playwright.CreateAsync();
//        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
//        var context = await browser.NewContextAsync();
//        _page = await context.NewPageAsync();

//        // Navigate to the login page
//        await _page.GotoAsync("https://example.com/login");

//        // Initialize assertion helper with the current page instance
//        _assertions = new LoginAssertions(_page);
//    }

//    [Test]
//    public async Task PerformLoginTest()
//    {
//        //await _page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();

//        // Call assertion methods
//        await _assertions.AssertUsernameFieldVisibleAsync();
//        await _assertions.AssertPasswordFieldVisibleAsync();
//       // await _assertions.AssertLoginButtonVisibleAndEnabledAsync();

//        // Interact with login elements
//        await _page.GetByLabel("UserName").FillAsync("laxmikant");
//        await _page.GetByLabel("Password").FillAsync("ghode");
//        await _page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

//        // Assert login success
//       // await _assertions.AssertLoginHeadingVisibleAsync();

//        //await _page.GetByRole(AriaRole.Img).ClickAsync();
//    }

//    [TearDown]
//    public async Task TearDown()
//    {
//        await _page.Context.CloseAsync();
//    }
//}
