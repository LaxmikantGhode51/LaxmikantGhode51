//using System;
//using System.Diagnostics;
//using System.IO;
//using System.Threading.Tasks;
//using Microsoft.Playwright;
//using NUnit.Framework;
//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;

//[TestFixture]
//public class PlaywrightTests
//{
//    private IPlaywright _playwright;
//    private IBrowser _browser;
//    private IBrowserContext _context;
//    private IPage _page;
//    private ExtentReports _extent;
//    private ExtentTest _test;

//    // Define the trace file path
//    private readonly string _traceFilePath = @"C:\Users\91954\source\repos\PlaywrightNunit\PlaywrightNunit\bin\Debug\net8.0\trace.zip";

//    [OneTimeSetUp]
//    public async Task OneTimeSetUp()
//    {
//        _playwright = await Playwright.CreateAsync();
//        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
//        {
//            Headless = false // Set to true to run tests in headless mode
//        });

//        // Initialize ExtentReports
//        var htmlReporter = new ExtentHtmlReporter(@"C:\Users\91954\source\repos\PlaywrightNunit\PlaywrightNunit\Reports");
//        _extent = new ExtentReports();
//        _extent.AttachReporter(htmlReporter);
//    }

//    [SetUp]
//    public async Task SetUp()
//    {
//        _context = await _browser.NewContextAsync();
//        _page = await _context.NewPageAsync();

//        // Start tracing to capture actions and snapshots
//        await _context.Tracing.StartAsync(new TracingStartOptions
//        {
//            Screenshots = true,
//            Snapshots = true,
//            Sources = true
//        });

//        // Create a test entry in ExtentReports
//        _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
//    }

//    [Test]
//    public async Task SampleTest()
//    {
//        try
//        {
//            _test.Log(Status.Info, "Navigating to the test page");
//            await _page.GotoAsync("https://testautomationpractice.blogspot.com/");

//            _test.Log(Status.Info, "Filling out the form");
//            await _page.GetByPlaceholder("Enter Name").FillAsync("laxmikant");
//            await _page.GetByPlaceholder("Enter EMail").FillAsync("laxmikantghode10@gmail.co");
//            await _page.GetByPlaceholder("Enter Phone").FillAsync("9834775453");
//            await _page.GetByLabel("Address:").FillAsync("pune");
//            await _page.GetByLabel("Male", new() { Exact = true }).CheckAsync();
//            await _page.GetByLabel("Sunday").CheckAsync();
//            await _page.GetByLabel("Country:").SelectOptionAsync(new[] { "india" });
//            await _page.GetByLabel("Colors:").SelectOptionAsync(new[] { "red" });
//            await _page.GetByLabel("Sorted List:").SelectOptionAsync(new[] { "cat" });
//            await _page.GetByPlaceholder("Start Date").FillAsync("2025-01-26");
//            await _page.GetByPlaceholder("End Date").FillAsync("2025-01-27");
//            await _page.Locator("#post-body-1307673142697428135").GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();

//            _test.Log(Status.Pass, "Form submitted successfully");
//        }
//        catch (Exception ex)
//        {
//            _test.Log(Status.Fail, $"Test failed with exception: {ex.Message}");
//            throw;
//        }
//    }

//    [TearDown]
//    public async Task TearDown()
//    {
//        // Ensure the directory exists before saving the trace file
//        var traceDirectory = Path.GetDirectoryName(_traceFilePath);
//        if (!Directory.Exists(traceDirectory))
//        {
//            Directory.CreateDirectory(traceDirectory);
//        }

//        // Stop tracing and save it to the specified file path
//        await _context.Tracing.StopAsync(new TracingStopOptions
//        {
//            Path = _traceFilePath
//        });

//        // Close the page and context
//        await _page.CloseAsync();
//        await _context.CloseAsync();

//        // Automatically open the trace report in the default browser
//        Process.Start(new ProcessStartInfo
//        {
//            FileName = "cmd",
//            Arguments = $"/c npx playwright show-trace \"{_traceFilePath}\"",
//            UseShellExecute = false,
//            CreateNoWindow = true
//        });
//    }

//    [OneTimeTearDown]
//    public async Task OneTimeTearDown()
//    {
//        await _browser.CloseAsync();
//        _playwright.Dispose();

//        // Flush the ExtentReports
//        _extent.Flush();
//    }
//}