using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDemo.Test
{
    public class EaSomee
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;
        private TraceViewerHelper _traceHelper;

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to true to run tests in headless mode
            });

            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            // Initialize the trace viewer helper
            _traceHelper = new TraceViewerHelper(_browser, _context, _page);

            // Start tracing before the test
            await _context.Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            await _page.GotoAsync("http://eaapp.somee.com/");
        }

        [Test]
        public async Task SampleTestTrace()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
            await _page.GetByLabel("UserName").ClickAsync();

            var usernameField = _page.GetByLabel("UserName");
            Assert.IsTrue(await usernameField.IsVisibleAsync(), "Username field is not visible");

            await _page.GetByLabel("UserNam").FillAsync("laxmikant");
            await _page.GetByLabel("Password").ClickAsync();

            var passwordField = _page.GetByLabel("Password");
            Assert.IsTrue(await passwordField.IsVisibleAsync(), "Password field is not visible");

            await _page.GetByLabel("Password").FillAsync("ghode");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
            await _page.GetByRole(AriaRole.Heading, new() { Name = "Login." }).ClickAsync();
            await _page.GetByRole(AriaRole.Img).ClickAsync();

        }

        [TearDown]
        public async Task TearDown()
        {
            // Stop tracing and handle trace files
            await _traceHelper.StopTracingAsync();
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _traceHelper.CleanupAsync(_playwright);
        }
    }
}
